using Microsoft.AspNetCore.Mvc;

namespace ASPCoreFirstApp.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Message()
        {
            return View();
        }

        public IActionResult Details(string name, int personality = 9)
        {
            ViewData["Name"] = name;
            ViewData["Personality"] = personality;

            return View("Message");
        }
        public IActionResult Data(int orderNumber, float price, int quantity)
        {
            return Json(new { OrderNumber = orderNumber, Price = price, Quantity =  quantity });
        }
    }
}
