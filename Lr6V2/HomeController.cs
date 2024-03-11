
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Lr6V2
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register(User user)
        {
            HttpContext.Session.SetString("UserName", user.Name);
            HttpContext.Session.SetInt32("UserAge", user.Age);
            return RedirectToAction("OrderQuantity");
        }

        public IActionResult OrderQuantity()
        {
            return View();
        }

        [HttpPost]
        public IActionResult OrderQuantity(int quantity)
        {
            HttpContext.Session.SetInt32("OrderQuantity", quantity);
            return RedirectToAction("OrderDetails");
        }

        public IActionResult OrderDetails()
        {
            return View();
        }

        [HttpPost]
        public IActionResult OrderDetails(List<Product> products)
        {
            string productsJson = JsonConvert.SerializeObject(products);
            HttpContext.Session.SetString("OrderProducts", productsJson);
            return RedirectToAction("OrderConfirmation");
        }

        public IActionResult OrderConfirmation()
        {
            var userName = HttpContext.Session.GetString("UserName");
            var userAge = HttpContext.Session.GetInt32("UserAge");
            var orderQuantity = HttpContext.Session.GetInt32("OrderQuantity");
            var productsJson = HttpContext.Session.GetString("OrderProducts");
            var orderProducts = JsonConvert.DeserializeObject<List<Product>>(productsJson);

            // Display the order confirmation with the retrieved data
            return View(orderProducts);
        }
    }
}