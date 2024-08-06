using AutoMapper;
using BLL.Abstract;
using Burgerci_Proje.Entities;
using Burgerci_Proje.Models;
using DAL.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Burgerci_Proje.Controllers
{
    public class MenuController : Controller
    {

        private readonly IMenuService _menuService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IMapper _mapper;
        private readonly AppDbContext db;

        public MenuController(IMenuService menuService, IMapper mapper, AppDbContext db)
        {
            _menuService = menuService;
            _mapper = mapper;
            this.db = db;
        }

        public async Task<IActionResult> Index() 
        {
        
            var allMenus = await _menuService.GetAllMenus();
            var allMenusMapped = _mapper.Map<List<MenuViewModel>>(allMenus);

            return View(allMenusMapped);
        }

        [HttpPost]
        public async Task<IActionResult> AddToBasket(MenuViewModel menuViewModel)
        {
            //TODO:Include çalışmıyor
            var menu = await _menuService.GetMenuWithIncludes(new[] { "Hamburger" });

            TempData["MenuData"] = JsonConvert.SerializeObject(menu.FirstOrDefault());

            return RedirectToAction("Index", "Order");
        }
    }
}
