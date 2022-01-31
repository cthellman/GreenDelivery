using GreenDelivery.Service.Models;

namespace GreenDelivery.Service.Data;

public static class Orders
{
    public static readonly Order NormalProducts = new(12345, new List<Product>()
    {
        Products.NormalProduct
    })
    {
        OrderDateTime = new DateTime(2022, 12, 12)
    };

    public static readonly Order NormalProductsThreeDaysInAdvanceMonWedFri = new(12345, new List<Product>()
    {
        Products.NormalProductThreeDaysInAdvance,
        Products.NormalProductTwoDaysInAdvance,
        Products.NormalProductOneDayInAdvance,
        Products.NormalProductMonWedFri
    })
        {
            OrderDateTime = new DateTime(2022,12,12)
        };

    public static readonly Order ExternalProductsTueThu = new(11243, new List<Product>()
    {
        Products.ExternalProduct,
        Products.ExternalProductTueThu
    })
    {
        OrderDateTime = new DateTime(2022, 12, 12)
    };

    public static readonly Order TemporaryProductsSatSun = new(13561, new List<Product>()
    {
        Products.TemporaryProductSatSun,
        Products.TemporaryProduct
    })
    {
        OrderDateTime = new DateTime(2022, 12, 12)
    };
}
