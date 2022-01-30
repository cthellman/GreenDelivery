namespace GreenDelivery.Service.Models;

public class Delivery
{
    public Delivery(int postalCode, DateTime deliveryDate)
    {
        PostalCode = postalCode;
        DeliveryDate = deliveryDate;
        IsGreenDelivery = false;
    }
    public int PostalCode { get; set; }
    public DateTime DeliveryDate { get; set; }
    public bool IsGreenDelivery { get; set; }
}