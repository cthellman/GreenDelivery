namespace GreenDelivery.Service.Models;

public class Delivery: IComparable<Delivery>
{
    private readonly DateTime _orderDate;

    public Delivery(int postalCode, DateTime deliveryDate, DateTime orderDate)
    {
        _orderDate = orderDate;
        PostalCode = postalCode;
        DeliveryDate = deliveryDate;
        IsGreenDelivery = false;
    }
    public int PostalCode { get; set; }
    public DateTime DeliveryDate { get; set; }
    public bool IsGreenDelivery { get; set; }

    public int CompareTo(Delivery? other)
    {
        if (other == null)
            return 1;
        
        if (DeliveryDate.Date < _orderDate.Date.AddDays(3))
            return other.IsGreenDelivery.CompareTo(IsGreenDelivery);
        
        return DeliveryDate.Date.CompareTo(other.DeliveryDate.Date);
    }
}