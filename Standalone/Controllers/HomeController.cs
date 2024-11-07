using Microsoft.AspNetCore.Mvc;
using Standalone.Helper;
using Standalone.Models;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Web;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Standalone.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string data)
        {
            string decryptedQueryData;
            if (string.IsNullOrEmpty(data))
            {
                return View("Error", "Invalid Data");
            }
            else {
                decryptedQueryData = EncryptDecrypt.Decrypt(data);
            }
            
            var queryParams = HttpUtility.ParseQueryString(decryptedQueryData);

            var viewModel = new POViewModel
            {
                PONo = queryParams["PONo"],
                PODate = DateTime.TryParse(queryParams["PODate"], out var poDate) ? poDate : (DateTime?)null,
                SupplierName = queryParams["SupplierName"],
                Charges = decimal.TryParse(queryParams["Charges"], out var charges) ? charges : (decimal?)null,
                CountryOfOrigin = queryParams["CountryOfOrigin"],
                ShippingTolerance = int.TryParse(queryParams["ShippingTolerance"], out var tolerance) ? tolerance : (int?)null,
                PortofLoading = queryParams["PortofLoading"],
                PortofDischarge = queryParams["PortofDischarge"],
                ShipmentMode = queryParams["ShipmentMode"]
            };

            return View(viewModel);

            //var viewModel = new POViewModel
            //{
            //    PONo = HttpContext.Request.Query["PONo"],
            //    PODate = DateTime.TryParse(HttpContext.Request.Query["PODate"], out var poDate) ? poDate : (DateTime?)null,  
            //    SupplierName = HttpContext.Request.Query["SupplierName"],
            //    Charges = decimal.TryParse(HttpContext.Request.Query["Charges"], out var charges) ? charges : (decimal?)null,
            //    CountryOfOrigin = HttpContext.Request.Query["CountryOfOrigin"],
            //    ShippingTolerance = int.TryParse(HttpContext.Request.Query["ShippingTolerance"], out var shippingTolerance) ? shippingTolerance : (int?)null,
            //    PortofLoading = HttpContext.Request.Query["PortofLoading"],
            //    PortofDischarge = HttpContext.Request.Query["PortofDischarge"],
            //    ShipmentMode = HttpContext.Request.Query["ShipmentMode"]
            //};


        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
