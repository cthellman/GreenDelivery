using GreenDelivery.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Dynamic;
using GreenDelivery.Service;
using GreenDelivery.Service.Data;
using GreenDelivery.Service.Models;

namespace GreenDelivery.Controllers
{
    public class DeliveryController : Controller
    {
        private readonly ILogger<DeliveryController> _logger;
        private readonly DeliveryService _deliveryService;

        public DeliveryController(ILogger<DeliveryController> logger)
        {
            _logger = logger;
            _deliveryService = new DeliveryService();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ExternalProducts()
        {
            var order = Orders.ExternalProductsTueThu;
            var model = new ViewModel
            {
                Dates = _deliveryService.GetDeliveryDates(order),
                Products = order.Products
            };
            return View("Delivery", model);
        }

        public IActionResult NormalProducts()
        {
            var order = Orders.NormalProductsThreeDaysInAdvanceMonWedFri;
            var model = new ViewModel
            {
                Dates = _deliveryService.GetDeliveryDates(order),
                Products = order.Products
            };
            return View("Delivery", model);
        }

        public IActionResult TemporaryProducts()
        {
            var order = Orders.TemporaryProductsSatSun;
            var model = new ViewModel
            {
                Dates = _deliveryService.GetDeliveryDates(order),
                Products = order.Products
            };
            return View("Delivery", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class ViewModel
    {
        public IEnumerable<Delivery> Dates { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}