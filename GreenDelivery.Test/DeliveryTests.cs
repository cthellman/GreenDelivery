using System;
using System.Collections.Generic;
using System.Linq;
using GreenDelivery.Service;
using GreenDelivery.Service.Data;
using GreenDelivery.Service.Models;
using Xunit;

namespace GreenDelivery.Test
{
    public class DeliveryTests
    {
        private readonly IDeliveryService _service = new DeliveryService();

        [Fact]
        public void ProductAndDeliveryOnSameWeekday_CanDeliverOnWeekday_ShouldBeTrue()
        {
            var product = new Product { DeliveryDays = new List<DayOfWeek> { DateTime.Now.DayOfWeek} };
            var delivery = new Delivery(0, DateTime.Now, DateTime.Now);
            Assert.True(_service.CanDeliverOnWeekday(product,delivery));
        }
        
        [Fact]
        public void ProductAndDeliveryOnNotSameWeekday_CanDeliverOnWeekday_ShouldBeFalse()
        {
            var product = new Product { DeliveryDays = new List<DayOfWeek> { DateTime.Now.AddDays(1).DayOfWeek } };
            var delivery = new Delivery(0, DateTime.Now, DateTime.Now);
            Assert.False(_service.CanDeliverOnWeekday(product, delivery));
        }

        [Fact]
        public void ProductNeedFourDays_DeliveryIsInFiveDays_CanDeliverOnTime_ShouldBeTrue()
        {
            var product = new Product { DaysInAdvance = 4};
            var delivery = new Delivery(0, DateTime.Now.AddDays(5), DateTime.Now);
            Assert.True(_service.CanDeliverOnTime(product, delivery, DateTime.Now));
        }

        [Fact]
        public void ProductNeedFourDays_DeliveryIsInTwoDays_CanDeliverOnTime_ShouldBeFalse()
        {
            var product = new Product { DaysInAdvance = 4 };
            var delivery = new Delivery(0, DateTime.Now.AddDays(2), DateTime.Now);
            Assert.False(_service.CanDeliverOnTime(product, delivery, DateTime.Now));
        }

        [Fact]
        public void ExternalProduct_DeliveryIsInSixDays_CanDeliverExternalProduct_ShouldBeTrue()
        {
            var product = new Product { ProductType = Product.ProductTypes.External };
            var delivery = new Delivery(0, DateTime.Now.AddDays(6), DateTime.Now);
            Assert.True(_service.CanDeliverExternalProduct(product, delivery, DateTime.Now));
        }

        [Fact]
        public void ExternalProduct_DeliveryIsInFiveDays_CanDeliverExternalProduct_ShouldBeFalse()
        {
            var product = new Product { ProductType = Product.ProductTypes.External };
            var delivery = new Delivery(0, DateTime.Now.AddDays(5), DateTime.Now);
            Assert.False(_service.CanDeliverExternalProduct(product, delivery, DateTime.Now));
        }

        [Fact]
        public void NotExternalProduct_CanDeliverExternalProduct_ShouldBeTrue()
        {
            var product = new Product();
            var delivery = new Delivery(0, DateTime.Now, DateTime.Now);
            Assert.True(_service.CanDeliverExternalProduct(product, delivery, DateTime.Now));
        }

        [Fact]
        public void TemporaryProduct_DeliveryIsInEightDays_CanDeliverTemporaryProduct_ShouldBeFalse()
        {
            var product = new Product { ProductType = Product.ProductTypes.Temporary };
            var delivery = new Delivery(0, DateTime.Now.AddDays(8), DateTime.Now);
            Assert.False(_service.CanDeliverTemporaryProduct(product, delivery, DateTime.Now));
        }

        [Fact]
        public void TemporaryProduct_DeliveryIsInFiveDays_CanDeliverTemporaryProduct_ShouldBeTrue()
        {
            var product = new Product { ProductType = Product.ProductTypes.Temporary };
            var delivery = new Delivery(0, DateTime.Now.AddDays(5), DateTime.Now);
            Assert.True(_service.CanDeliverTemporaryProduct(product, delivery, DateTime.Now));
        }

        [Fact]
        public void NotTemporaryProduct_CanDeliverTemporaryProduct_ShouldBeTrue()
        {
            var product = new Product();
            var delivery = new Delivery(0, DateTime.Now, DateTime.Now);
            Assert.True(_service.CanDeliverTemporaryProduct(product, delivery, DateTime.Now));
        }

        [Fact]
        public void DeliveryOnTheEight_IsGreenDelivery_ShouldBeTrue()
        {
            var delivery = new Delivery(0, new DateTime(2022,12,8), DateTime.Now);
            Assert.True(_service.IsGreenDelivery(delivery));
        }

        [Fact]
        public void DeliveryOnTheThirteenth_IsGreenDelivery_ShouldBeFalse()
        {
            var delivery = new Delivery(0, new DateTime(2022, 12, 13), DateTime.Now);
            Assert.False(_service.IsGreenDelivery(delivery));
        }
    }
}