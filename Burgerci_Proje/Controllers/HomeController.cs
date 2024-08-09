using Burgerci_Proje.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Burgerci_Proje.Controllers
{
    public class HomeController : Controller
    {
        // tüm menüler burada gözükecek sipariþ detayý vs burada olacak
        // anasayfa ekraný
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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
    //asd
}
