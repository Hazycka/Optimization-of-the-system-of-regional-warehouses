using System.Globalization;
using System.Text.Json;
using VKR_WEB.Models;

namespace VKR_WEB.Services
{
    public class SimulatedAnnealing
    {
        public float LastStateEnergy { get; private set; }

        private IEnumerable<Warehouse> _warehouses;
        private IEnumerable<DeliveryPoint> _deliveryPoints;
        private float _maxT;
        private float _minT;
        private float _costPerKm;
        private Random _random = new();

        public SimulatedAnnealing(IEnumerable<Warehouse> warehouses, IEnumerable<DeliveryPoint> deliveryPoints, Settings settings)
        {
            _warehouses = warehouses;
            _deliveryPoints = deliveryPoints;
            _maxT = settings.MaxTemperature;
            _minT = settings.MinTemperature;
            _costPerKm = settings.CostPerKm;
        }

        public IEnumerable<Warehouse> GetOptimalWarehouses()
        {
            float currentT = _maxT;
            var currentState = GetInitialState();
            var currentStateEnergy = GetStateEnergy(currentState);
            int i = 0;

            while (currentT >= _minT)
            {
                i++;
                var stateCandidate = GenerateStateCandidate(currentState);
                var candidateEnergy = GetStateEnergy(stateCandidate);

                if (candidateEnergy < currentStateEnergy)
                {
                    currentState = stateCandidate;
                    currentStateEnergy = candidateEnergy;
                }
                else
                {
                    if (AttemptingToTransition(candidateEnergy - currentStateEnergy, currentT))
                    {
                        currentState = stateCandidate;
                        currentStateEnergy = candidateEnergy;
                    }
                }

                currentT = DecreaseTemperature(i);
            }

            LastStateEnergy = currentStateEnergy;

            return currentState;
        }

        // Генерация нового возможного состояния
        private List<Warehouse> GenerateStateCandidate(List<Warehouse> warehouses)
        {
            var stateCandidate = GetWarehousesClone(warehouses);
            // Изменяем состояние активности одного из складов
            var randNum = _random.Next(0, stateCandidate.Count);
            stateCandidate[randNum].IsActive = !stateCandidate[randNum].IsActive;

            if (stateCandidate.Any(m => m.IsActive))
                SetWarehouses_DeliveryPoints(stateCandidate);

            return stateCandidate;
        }

        // Вычисление энерегии состояния
        private float GetStateEnergy(List<Warehouse> warehouses)
        {
            float resultEnergy = 0;
            foreach (var warehouse in warehouses.Where(m => m.IsActive))
            {
                resultEnergy += warehouse.Cost;
                foreach (var deliveryPoint in warehouse.DeliveryPoints_Distances)
                {
                    resultEnergy += deliveryPoint.Value / 1000 * _costPerKm * deliveryPoint.Key.Frequency;
                }
            }

            if (resultEnergy == 0)
                resultEnergy = float.PositiveInfinity;

            return resultEnergy;
        }

        // Выполение попытки вероятностного перехода в новое состояние
        private bool AttemptingToTransition(float deltaEnergy, float currentTemperature)
        {
            // Вероятность перехода
            double P = Math.Exp((-deltaEnergy) / currentTemperature);
            var randNum = _random.NextDouble();
            bool result = randNum <= P;

            return result;
        }

        // Получение начального состояния.
        private List<Warehouse> GetInitialState()
        {
            List<Warehouse> newWarehouses = GetWarehousesClone(_warehouses.ToList());

            foreach (var warehouse in newWarehouses)
            {
                warehouse.IsActive = _random.Next(2) == 1;
            }
            if (newWarehouses.Any(m => m.IsActive))
                SetWarehouses_DeliveryPoints(newWarehouses);

            return newWarehouses;
        }

        private float DecreaseTemperature(int iter)
        {
            float T = _maxT * 0.1f / iter;
            return T;
        }

        // создание таблицы расстояний
        public async Task SetPointsWarehouses()
        {
            HttpClient client = new HttpClient();

            foreach (var point in _deliveryPoints)
            {
                foreach (var warehouse in _warehouses)
                {
                    if (!point.Warehouses_Distances.ContainsKey(warehouse))
                    {
                        string url = $"http://router.project-osrm.org/route/v1/car/{point.Coordinates.Longitude.ToString(CultureInfo.InvariantCulture)}," +
                            $"{point.Coordinates.Latitude.ToString(CultureInfo.InvariantCulture)};" +
                            $"{warehouse.Coordinates.Longitude.ToString(CultureInfo.InvariantCulture)}," +
                            $"{warehouse.Coordinates.Latitude.ToString(CultureInfo.InvariantCulture)}";
                        var responceJson = await client.GetStringAsync(url);
                        var routeService = JsonSerializer.Deserialize<RouteService>(responceJson);
                        point.Warehouses_Distances.Add(warehouse, routeService.Routes[0].Distance);
                    }
                }
            }
        }

        // Сопоставление каждому складу клиентов по наименьшему расстоянию меж ними.
        private void SetWarehouses_DeliveryPoints(List<Warehouse> warehouses)
        {
            foreach (var deliveryPoint in _deliveryPoints)
            {
                float minDistance = float.PositiveInfinity;
                Warehouse actualWarehouse = new();

                foreach (var warehouse in warehouses.Where(m => m.IsActive))
                {
                    float distance = deliveryPoint.Warehouses_Distances.First(m => m.Key.Name.Equals(warehouse.Name)).Value;
                    if (minDistance > distance)
                    {
                        minDistance = distance;
                        actualWarehouse = warehouse;
                    }
                }

                actualWarehouse.DeliveryPoints_Distances.Add(deliveryPoint, minDistance);
            }
        }

        // Создание нового массива путем глубокого копирования.
        private List<Warehouse> GetWarehousesClone(List<Warehouse> warehouses)
        {
            List<Warehouse> newWarehouses = new();

            foreach (var warehouse in warehouses)
            {
                newWarehouses.Add((Warehouse)warehouse.Clone());
            }

            return newWarehouses;
        }
    }
}
