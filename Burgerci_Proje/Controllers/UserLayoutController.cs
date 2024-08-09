using Microsoft.AspNetCore.Mvc;

namespace Burgerci_Proje.Controllers
{
    public class UserLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
