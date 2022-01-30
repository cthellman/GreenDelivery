using GreenDelivery.Service.Models;

namespace GreenDelivery.Service
{
    public class DeliveryService : IDeliveryService
    {
        public IEnumerable<Delivery> GetDeliveryDates(Order order)
        {
            var deliveryDates = order.PossibleDeliveryDates;
            
            foreach (var product in order.Products)
            {
                foreach (var deliveryDate in deliveryDates)
                {
                    if (!CanDeliverOnWeekday(product, deliveryDate))
                        deliveryDates.Remove(deliveryDate);

                    if (!CanDeliverOnTime(product, deliveryDate, order.OrderDateTime))
                        deliveryDates.Remove(deliveryDate);

                    if (!CanDeliverExternalProduct(product, deliveryDate, order.OrderDateTime))
                        deliveryDates.Remove(deliveryDate);

                    if (!CanDeliverTemporaryProduct(product, deliveryDate, order.OrderDateTime))
                        deliveryDates.Remove(deliveryDate);

                    deliveryDate.IsGreenDelivery = IsGreenDelivery(product,deliveryDate, order.OrderDateTime);
                }
            }
            return deliveryDates;
        }

        public bool CanDeliverOnWeekday(Product product, Delivery delivery)
        {
            return product.DeliveryDays.Contains(delivery.DeliveryDate.DayOfWeek);
        }

        public bool CanDeliverOnTime(Product product, Delivery delivery, DateTime orderDateTime)
        {
            return delivery.DeliveryDate > orderDateTime.AddDays(product.DaysInAdvance);
        }

        public bool CanDeliverExternalProduct(Product product, Delivery delivery, DateTime orderDateTime)
        {
            if (product.ProductType != Product.ProductTypes.External)
                return true;

            return delivery.DeliveryDate > orderDateTime.AddDays(5);
        }

        public bool CanDeliverTemporaryProduct(Product product, Delivery delivery, DateTime orderDateTime)
        {
            if (product.ProductType != Product.ProductTypes.Temporary)
                return true;

            return delivery.DeliveryDate < orderDateTime.AddDays(7);
        }

        public bool IsGreenDelivery(Product product, Delivery delivery, DateTime orderDateTime)
        {
            return delivery.DeliveryDate.Day % 7 == 0;
        }

    }
}