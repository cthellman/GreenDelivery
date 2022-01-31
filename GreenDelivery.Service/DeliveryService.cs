using GreenDelivery.Service.Models;

namespace GreenDelivery.Service
{
    public class DeliveryService : IDeliveryService
    {
        public IEnumerable<Delivery> GetDeliveryDates(Order order)
        {
            var deliveryDates = new List<Delivery>();
            for (var i = 1; i < 15; i++)
            {
                deliveryDates.Add(new Delivery(order.PostalCode, order.OrderDateTime.AddDays(i)));
            }

            foreach (var product in order.Products)
            {
                for (var i = 0;i<deliveryDates.Count;i++)
                {
                    deliveryDates[i].IsGreenDelivery = IsGreenDelivery(deliveryDates[i]);

                    if (!CanDeliverOnWeekday(product, deliveryDates[i]))
                    {
                        deliveryDates.RemoveAt(i);
                        continue;
                    }

                    if (!CanDeliverOnTime(product, deliveryDates[i], order.OrderDateTime))
                    {
                        deliveryDates.RemoveAt(i);
                        continue;
                    }

                    if (!CanDeliverExternalProduct(product, deliveryDates[i], order.OrderDateTime))
                    {
                        deliveryDates.RemoveAt(i);
                        continue;
                    }

                    if (!CanDeliverTemporaryProduct(product, deliveryDates[i], order.OrderDateTime))
                    {
                        deliveryDates.RemoveAt(i);
                    }
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
            return delivery.DeliveryDate.Date > orderDateTime.AddDays(product.DaysInAdvance).Date;
        }

        public bool CanDeliverExternalProduct(Product product, Delivery delivery, DateTime orderDateTime)
        {
            if (product.ProductType != Product.ProductTypes.External)
                return true;

            return delivery.DeliveryDate.Date > orderDateTime.AddDays(5).Date;
        }

        public bool CanDeliverTemporaryProduct(Product product, Delivery delivery, DateTime orderDateTime)
        {
            if (product.ProductType != Product.ProductTypes.Temporary)
                return true;

            return delivery.DeliveryDate.Date > orderDateTime.AddDays(7).Date;
        }

        public bool IsGreenDelivery(Delivery delivery)
        {
            return delivery.DeliveryDate.Day % 3 == 0;
        }

    }
}