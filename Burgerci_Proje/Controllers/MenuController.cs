using Microsoft.AspNetCore.Mvc;

namespace Burgerci_Proje.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddToBasket()
        {
            //service ekle, tuşuna basılan menüyü getir
            return RedirectToAction("Index", "Order");
        }
    }
}
