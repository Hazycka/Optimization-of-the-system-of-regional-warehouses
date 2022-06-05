namespace VKR_WEB.Models
{
    public class DeliveryPoint
    {
        // Название по которому можно идентифицировать точку.
        public string Name { get; set; }
        // Координаты расположения точки.
        public Coordinates Coordinates { get; set; }
        // Количество рейсов до точки в месяц.
        public int Frequency { get; set; }
        public Dictionary<Warehouse, float> Warehouses_Distances = new();
    }
}
