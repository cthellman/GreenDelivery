namespace GreenDelivery.Service.Models;

public class Product
{
    public enum ProductTypes
    {
        Normal,
        External,
        Temporary
    }

    public Guid ProductId { get; set; } = Guid.NewGuid();
    public string ProductName { get; set; }
    public List<DayOfWeek> DeliveryDays { get; init; } = new();
    public ProductTypes ProductType { get; init; } = ProductTypes.Normal;
    public int DaysInAdvance { get; init; }
}