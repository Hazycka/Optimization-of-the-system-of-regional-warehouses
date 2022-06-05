namespace VKR_WEB.Models
{
    public class Warehouse : ICloneable
    {
        // Название по которому можно идентифицировать склад.
        public string Name { get; set; }
        // Активен ли склад.
        public bool IsActive { get; set; }
        // Координаты склада.
        public Coordinates Coordinates { get; set; }
        // Стоимость аренды склада.
        public float Cost { get; set; }
        // Список обслуживаемых клиентов и дистанцит до них.
        public Dictionary<DeliveryPoint, float> DeliveryPoints_Distances { get; set; } = new();

        public object Clone() => new Warehouse() { Name = this.Name, IsActive = this.IsActive, Coordinates = this.Coordinates, Cost = this.Cost, DeliveryPoints_Distances = new() };
    }
}
