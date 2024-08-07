using AutoMapper;
using BLL.Abstract;
using BLL.Concrete;
using BLL.DTOs;
using Burgerci_Proje.Models;
using Microsoft.AspNetCore.Mvc;

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

        public MenuController(IMapper mapper, IMenuService menuService, IGarnitureService garnitureService, IDrinkService drinkService,IHamburgerService hamburgerService, IExtraService extraService)
        {
            _mapper = mapper;
            _menuService = menuService;
            _garnitureService = garnitureService;
            _drinkService = drinkService;
            _hamburgerService = hamburgerService;
            _extraService = extraService;
        }

        public async Task<IActionResult> MenuList()
        {
            var menus = await _menuService.GetAllMenus();
            var mappedMenus = _mapper.Map<List<MenuViewModel>>(menus);
            return View(mappedMenus);
        }
        public async Task<IActionResult> GetHamburgers()
        {
            var hamburgers = await _hamburgerService.GetAllHamburgers();
            var mappedHamburgers = _mapper.Map<List<HamburgerViewModel>>(hamburgers);
            return Json(mappedHamburgers);
        }

        public async Task<IActionResult> GetGarnitures()
        {
            var garnitures = await _garnitureService.GetAllGarnitures();
            var mappedGarnitures = _mapper.Map<List<GarnitureViewModel>>(garnitures);
            return Json(mappedGarnitures);
        }

        public async Task<IActionResult> GetDrinks()
        {
            var drinks = await _drinkService.GetAllDrinks();
            var mappedDrinks = _mapper.Map<List<DrinkViewModel>>(drinks);
            return Json(mappedDrinks);
        }


    }
}
