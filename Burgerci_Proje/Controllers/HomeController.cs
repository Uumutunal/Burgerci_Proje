﻿using Microsoft.AspNetCore.Mvc;

namespace Burgerci_Proje.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
