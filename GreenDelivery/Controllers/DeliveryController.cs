using GreenDelivery.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using GreenDelivery.Service;
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

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Delivery(Basket basket)
        {
            var dates = _deliveryService.GetDeliveryDates(basket);
            return View(dates);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}