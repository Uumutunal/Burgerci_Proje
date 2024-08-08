using AutoMapper;
using BLL.Abstract;
using BLL.Concrete;
using BLL.DTOs;
using Burgerci_Proje.Entities;
using Burgerci_Proje.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Burgerci_Proje.Controllers
{
    public class MenuController : Controller
    {

        private readonly IMapper _mapper;
        private readonly IMenuService _menuService;
        private readonly IGarnitureService _garnitureService;
        private readonly IDrinkService _drinkService;
        private readonly IHamburgerService _hamburgerService;
        private readonly IExtraService _extraService;
        private readonly IUserService _userService;

        public MenuController(IMapper mapper, IMenuService menuService, IGarnitureService garnitureService, IDrinkService drinkService,IHamburgerService hamburgerService, IExtraService extraService, IUserService userService)
        {
            _mapper = mapper;
            _menuService = menuService;
            _garnitureService = garnitureService;
            _drinkService = drinkService;
            _hamburgerService = hamburgerService;
            _extraService = extraService;
            _userService = userService;
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

            var menu = await _menuService.GetMenuWithIncludes(new[] { "Hamburger", "Drink", "Extra" });


            TempData["MenuData"] = JsonConvert.SerializeObject(menu.FirstOrDefault());

            return RedirectToAction("OrderMenu", "Order");
        }
        public async Task<IActionResult> MenuList()
        {
            var menus = await _menuService.GetAllMenus();
            var mappedMenus = _mapper.Map<List<MenuViewModel>>(menus);

            ViewBag.IsAdmin = HttpContext.Session.GetString("IsAdmin");


            return View(mappedMenus);
        }
        public async Task<IActionResult> GetHamburgers()
        {
            var hamburgers = await _hamburgerService.GetAllHamburgers();
            var mappedHamburgers = _mapper.Map<List<HamburgerViewModel>>(hamburgers);
            return Json(mappedHamburgers);
        }

        public async Task<IActionResult> GetExtras()
        {
            var extras = await _extraService.GetAllExtra();
            var mappedExtras = _mapper.Map<List<ExtraViewModel>>(extras);
            return Json(mappedExtras);
        }

        public async Task<IActionResult> GetDrinks()
        {
            var drinks = await _drinkService.GetAllDrinks();
            var mappedDrinks = _mapper.Map<List<DrinkViewModel>>(drinks);
            return Json(mappedDrinks);

        }


    }
}
