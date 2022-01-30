using System;
using System.Collections.Generic;
using System.Linq;
using GreenDelivery.Service;
using GreenDelivery.Service.Models;
using Xunit;

namespace GreenDelivery.Test
{
    public class DeliveryTests
    {
        private IDeliveryService _service = new DeliveryService();

        [Fact]
        public void CreateNewOrder_InputEmpty_ShouldGiveTwoWeeksDeliveryDates()
        {
            var order = new Order(0,new List<Product>());

            Assert.True(order.PossibleDeliveryDates.Count == 14);
            Assert.True(order.PossibleDeliveryDates.Max(d =>d.DeliveryDate.Date == order.OrderDateTime.AddDays(14).Date));
        }

        [Fact]
        public void ProductAndDeliveryOnSameWeekday_CanDeliverOnWeekday_ShouldBeTrue()
        {
            var product = new Product { DeliveryDays = new List<DayOfWeek> { DateTime.Now.DayOfWeek} };
            var delivery = new Delivery(0, DateTime.Now);
            Assert.True(_service.CanDeliverOnWeekday(product,delivery));
        }
        
        [Fact]
        public void ProductAndDeliveryOnNotSameWeekday_CanDeliverOnWeekday_ShouldBeFalse()
        {
            var product = new Product { DeliveryDays = new List<DayOfWeek> { DateTime.Now.AddDays(1).DayOfWeek } };
            var delivery = new Delivery(0, DateTime.Now);
            Assert.False(_service.CanDeliverOnWeekday(product, delivery));
        }

        [Fact]
        public void ProductNeedFourDays_DeliveryIsInFiveDays_CanDeliverOnTime_ShouldBeTrue()
        {
            var product = new Product { DaysInAdvance = 4};
            var delivery = new Delivery(0, DateTime.Now.AddDays(5));
            Assert.True(_service.CanDeliverOnTime(product, delivery, DateTime.Now));
        }

        [Fact]
        public void ProductNeedFourDays_DeliveryIsInTwoDays_CanDeliverOnTime_ShouldBeFalse()
        {
            var product = new Product { DaysInAdvance = 4 };
            var delivery = new Delivery(0, DateTime.Now.AddDays(2));
            Assert.False(_service.CanDeliverOnTime(product, delivery, DateTime.Now));
        }

        [Fact]
        public void ExternalProduct_DeliveryIsInSixDays_CanDeliverExternalProduct_ShouldBeTrue()
        {
            var product = new Product { ProductType = Product.ProductTypes.External };
            var delivery = new Delivery(0, DateTime.Now.AddDays(6));
            Assert.True(_service.CanDeliverExternalProduct(product, delivery, DateTime.Now));
        }

        [Fact]
        public void ExternalProduct_DeliveryIsInFiveDays_CanDeliverExternalProduct_ShouldBeFalse()
        {
            var product = new Product { ProductType = Product.ProductTypes.External };
            var delivery = new Delivery(0, DateTime.Now.AddDays(5));
            Assert.False(_service.CanDeliverExternalProduct(product, delivery, DateTime.Now));
        }

        [Fact]
        public void CanDeliverExternalProduct()
        {
            //if (product.ProductType != Product.ProductTypes.External)
            //    return true;

            //return delivery.DeliveryDate < orderDateTime.AddDays(5);
        }

        [Fact]
        public void CanDeliverTemporaryProduct()
        {
            //if (product.ProductType != Product.ProductTypes.Temporary)
            //    return true;

            //return delivery.DeliveryDate < orderDateTime.AddDays(7);
        }

        [Fact]
        public void IsGreenDelivery()
        {
            //return delivery.DeliveryDate.Day % 7 == 0;
        }

    }

}