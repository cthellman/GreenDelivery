using GreenDelivery.Service.Models;

namespace GreenDelivery.Service.Data;

public static class Products
{
    public static readonly Product NormalProductThreeDaysInAdvance = new()
    {
        DaysInAdvance = 3,
        DeliveryDays = new List<DayOfWeek>
        {
            DayOfWeek.Monday,
            DayOfWeek.Tuesday,
            DayOfWeek.Wednesday,
            DayOfWeek.Thursday,
            DayOfWeek.Friday,
            DayOfWeek.Saturday,
            DayOfWeek.Sunday
        },
        ProductName = "Gurka",
        ProductType = Product.ProductTypes.Normal
    };

    public static readonly Product NormalProductTwoDaysInAdvance = new()
    {
        DaysInAdvance = 2,
        DeliveryDays = new List<DayOfWeek>
        {
            DayOfWeek.Monday,
            DayOfWeek.Tuesday,
            DayOfWeek.Wednesday,
            DayOfWeek.Thursday,
            DayOfWeek.Friday,
            DayOfWeek.Saturday,
            DayOfWeek.Sunday

        },
        ProductName = "Tomat",
        ProductType = Product.ProductTypes.Normal
    };

    public static readonly Product NormalProductOneDayInAdvance = new()
    {
        DaysInAdvance = 1,
        DeliveryDays = new List<DayOfWeek>
        {
            DayOfWeek.Monday,
            DayOfWeek.Tuesday,
            DayOfWeek.Wednesday,
            DayOfWeek.Thursday,
            DayOfWeek.Friday,
            DayOfWeek.Saturday,
            DayOfWeek.Sunday

        },
        ProductName = "Halloumi",
        ProductType = Product.ProductTypes.Normal
    };

    public static readonly Product NormalProductMonWedFri = new()
    {
        DaysInAdvance = 0,
        DeliveryDays = new List<DayOfWeek>
        {
            DayOfWeek.Monday,
            DayOfWeek.Wednesday,
            DayOfWeek.Friday,

        },
        ProductName = "Lök",
        ProductType = Product.ProductTypes.Normal
    };

    public static readonly Product ExternalProduct = new()
    {
        DaysInAdvance = 0,
        DeliveryDays = new List<DayOfWeek>
        {
            DayOfWeek.Monday,
            DayOfWeek.Tuesday,
            DayOfWeek.Wednesday,
            DayOfWeek.Thursday,
            DayOfWeek.Friday,
            DayOfWeek.Saturday,
            DayOfWeek.Sunday

        },
        ProductName = "Palsternacka",
        ProductType = Product.ProductTypes.External
    };

    public static readonly Product ExternalProductTueThu = new()
    {
        DaysInAdvance = 0,
        DeliveryDays = new List<DayOfWeek>
        {
            DayOfWeek.Tuesday,
            DayOfWeek.Thursday,
        },
        ProductName = "Ostron",
        ProductType = Product.ProductTypes.External
    };

    public static readonly Product TemporaryProductSatSun = new()
    {
        DaysInAdvance = 0,
        DeliveryDays = new List<DayOfWeek>
        {
            DayOfWeek.Saturday,
            DayOfWeek.Sunday

        },
        ProductName = "Köttben",
        ProductType = Product.ProductTypes.Temporary
    };

    public static readonly Product TemporaryProduct = new()
    {
        DaysInAdvance = 0,
        DeliveryDays = new List<DayOfWeek>
        {
            DayOfWeek.Monday,
            DayOfWeek.Tuesday,
            DayOfWeek.Wednesday,
            DayOfWeek.Thursday,
            DayOfWeek.Friday,
            DayOfWeek.Saturday,
            DayOfWeek.Sunday
        },
        ProductName = "Falukorv",
        ProductType = Product.ProductTypes.Temporary
    };
}