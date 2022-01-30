using GreenDelivery.Service.Models;

namespace GreenDelivery.Service;

public interface IDeliveryService
{
    IEnumerable<Delivery> GetDeliveryDates(Order order);
    bool CanDeliverOnWeekday(Product product, Delivery delivery);
    bool CanDeliverOnTime(Product product, Delivery delivery, DateTime orderDateTime);
    bool CanDeliverExternalProduct(Product product, Delivery delivery, DateTime orderDateTime);
    bool CanDeliverTemporaryProduct(Product product, Delivery delivery, DateTime orderDateTime);
    bool IsGreenDelivery(Delivery delivery);
}