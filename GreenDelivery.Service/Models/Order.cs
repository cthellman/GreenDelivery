namespace GreenDelivery.Service.Models;

public class Order
{
    public Order(int postalCode, IEnumerable<Product> products)
    {
        OrderDateTime = DateTime.Now;
        Products = products;
        for (var i = 1; i < 15; i++)
        {
            PossibleDeliveryDates.Add(new Delivery(postalCode, OrderDateTime.AddDays(i)));
        }
    }

    public IEnumerable<Product> Products { get; set; }
    public DateTime OrderDateTime { get; set; }
    public List<Delivery> PossibleDeliveryDates { get; set; } = new();
}