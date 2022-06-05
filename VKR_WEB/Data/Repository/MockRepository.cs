using VKR_WEB.Models;

namespace VKR_WEB.Data.Repository
{
    public class MockRepository : IRepository
    {
        private List<Warehouse> _warehouses;
        private List<DeliveryPoint> _deliveryPoints;
        private Settings _settings;

        public MockRepository()
        {
            _warehouses = new List<Warehouse>()
            {
                new Warehouse()
                {
                    Name = "Дачный проспект",
                    IsActive = false,
                    Coordinates = new(30.2412f, 59.8490f),
                    Cost = 90000,
                    DeliveryPoints_Distances = new()
                },
                new Warehouse()
                {
                    Name = "Замшина улица",
                    IsActive = false,
                    Coordinates = new(30.3999f, 59.9749f),
                    Cost = 120000,
                    DeliveryPoints_Distances = new()
                },
                new Warehouse()
                {
                    Name = "Юбилейный квартал",
                    IsActive = false,
                    Coordinates = new(30.2355f, 60.02948f),
                    Cost = 150000,
                    DeliveryPoints_Distances = new()
                },
                new Warehouse()
                {
                    Name = "Светлановский проспект",
                    IsActive = false,
                    Coordinates = new(30.39818f, 60.03929f),
                    Cost = 170000,
                    DeliveryPoints_Distances = new()
                },
                new Warehouse()
                {
                    Name = "Морская слава",
                    IsActive = false,
                    Coordinates = new(30.24138f, 59.92614f),
                    Cost = 300000,
                    DeliveryPoints_Distances = new()
                },
                new Warehouse()
                {
                    Name = "Красные зори",
                    IsActive = false,
                    Coordinates = new(29.9466f, 59.85598f),
                    Cost = 135000,
                    DeliveryPoints_Distances = new()
                },
                new Warehouse()
                {
                    Name = "Волково",
                    IsActive = false,
                    Coordinates = new(30.35463f, 59.90697f),
                    Cost = 200000,
                    DeliveryPoints_Distances = new()
                },
                new Warehouse()
                {
                    Name = "Сосновка",
                    IsActive = false,
                    Coordinates = new(30.48039f, 59.87868f),
                    Cost = 140000,
                    DeliveryPoints_Distances = new()
                }
            };
            _deliveryPoints = new List<DeliveryPoint>()
            {
                new DeliveryPoint()
                {
                    Name = "Новая деревня",
                    Coordinates = new(30.27717f, 59.9857f),
                    Frequency = 7
                },
                new DeliveryPoint()
                {
                    Name = "Красногвардейский район",
                    Coordinates = new(30.47646f, 59.95586f),
                    Frequency = 17
                },
                new DeliveryPoint()
                {
                    Name = "Сосновая поляна",
                    Coordinates = new(30.15854f,59.8398f),
                    Frequency = 10
                },
                new DeliveryPoint()
                {
                    Name = "Купчино",
                    Coordinates = new(30.40162f, 59.83394f),
                    Frequency = 20
                },
                new DeliveryPoint()
                {
                    Name = "Ольгино",
                    Coordinates = new(30.14f, 60.00052f),
                    Frequency = 4
                },
                new DeliveryPoint()
                {
                    Name = "Песочное",
                    Coordinates = new(30.16392f, 60.11983f),
                    Frequency = 6
                },
                new DeliveryPoint()
                {
                    Name = "Выборгский район",
                    Coordinates = new(30.33432f, 60.03655f),
                    Frequency = 12
                },
                new DeliveryPoint()
                {
                    Name = "Калинский район",
                    Coordinates = new(30.40574f, 60.00464f),
                    Frequency = 16
                },
                new DeliveryPoint()
                {
                    Name = "Мурино",
                    Coordinates = new(30.43114f, 60.05506f),
                    Frequency = 10
                },
                new DeliveryPoint()
                {
                    Name = "Петроградский район",
                    Coordinates = new(30.31319f, 59.95801f),
                    Frequency = 20
                },
                new DeliveryPoint()
                {
                    Name = "Безымянный остров",
                    Coordinates = new(30.37621f, 59.94004f),
                    Frequency = 22
                },
                new DeliveryPoint()
                {
                    Name = "Адмиралтейский район",
                    Coordinates = new(30.29328f, 59.91054f),
                    Frequency = 16
                },
                new DeliveryPoint()
                {
                    Name = "Фрунзенский",
                    Coordinates = new(30.38582f, 59.87221f),
                    Frequency = 30
                },
                new DeliveryPoint()
                {
                    Name = "Клочки",
                    Coordinates = new(30.45738f, 59.91415f),
                    Frequency = 13
                },
                new DeliveryPoint()
                {
                    Name = "Московский район",
                    Coordinates = new(30.31628f, 59.83144f),
                    Frequency = 10
                },
                new DeliveryPoint()
                {
                    Name = "Петродворцовый район",
                    Coordinates = new(29.8436f, 59.87304f),
                    Frequency = 11
                },
                new DeliveryPoint()
                {
                    Name = "Ломоносов",
                    Coordinates = new(29.77471f, 59.9046f),
                    Frequency = 6
                },
                new DeliveryPoint()
                {
                    Name = "Кронштадт",
                    Coordinates = new(29.77402f, 59.99331f),
                    Frequency = 9
                },
                new DeliveryPoint()
                {
                    Name = "Новоизмайловский",
                    Coordinates = new(30.30617f, 59.8636f),
                    Frequency = 8
                }
            };
            _settings = new(10, 0.000001f, 300);
        }

        public bool AddDeliveryPoint(DeliveryPoint deliveryPoint)
        {
            _deliveryPoints.Add(deliveryPoint);
            return true;
        }

        public bool AddWarehouse(Warehouse warehouse)
        {
            _warehouses.Add(warehouse);
            return true;
        }

        public bool ChangeSettings(Settings settings)
        {
            _settings = settings;
            return true;
        }

        public bool DeleteDeliveryPoint(DeliveryPoint deliveryPoint)
        {
            if(_deliveryPoints.Any(m=>m == deliveryPoint))
            {
                _deliveryPoints.Remove(deliveryPoint);
                return true;
            }

            return false;
        }

        public bool DeleteWarehouse(Warehouse warehouse)
        {
            if (_warehouses.Any(m => m == warehouse))
            {
                _warehouses.Remove(warehouse);
                return true;
            }

            return false;
        }

        public List<DeliveryPoint> GetDeliveryPoints()
        {
            return _deliveryPoints;
        }

        public Settings GetSettings()
        {
            return _settings;
        }

        public List<Warehouse> GetWarehouses()
        {
            return _warehouses;
        }
    }
}
