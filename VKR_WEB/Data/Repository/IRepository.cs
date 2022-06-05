using VKR_WEB.Models;

namespace VKR_WEB.Data.Repository
{
    public interface IRepository
    {
        List<DeliveryPoint> GetDeliveryPoints();
        List<Warehouse> GetWarehouses();
        bool AddDeliveryPoint(DeliveryPoint deliveryPoint);
        bool DeleteDeliveryPoint(DeliveryPoint deliveryPoint);
        bool AddWarehouse(Warehouse warehouse);
        bool DeleteWarehouse(Warehouse warehouse);
        Settings GetSettings();
        bool ChangeSettings(Settings settings);
    }
}
