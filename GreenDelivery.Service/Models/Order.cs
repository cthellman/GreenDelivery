namespace GreenDelivery.Service.Models;

public class Order
{
    public Order(int postalCode, List<Product> products)
    {
        OrderDateTime = DateTime.Now;
        PostalCode = postalCode;
        Products = products;
    }

    public int PostalCode { get; }
    public List<Product> Products { get; }
    public DateTime OrderDateTime { get; init; }
    public List<Delivery> PossibleDeliveryDates { get; set; } = new();
}