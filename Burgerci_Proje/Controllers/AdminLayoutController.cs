using Microsoft.AspNetCore.Mvc;

namespace Burgerci_Proje.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
