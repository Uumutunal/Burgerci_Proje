using AutoMapper;
using BLL.Abstract;
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

        public MenuController(IMapper mapper, IMenuService menuService, IGarnitureService garnitureService, IDrinkService drinkService)
        {
            _mapper = mapper;
            _menuService = menuService;
            _garnitureService = garnitureService;
            _drinkService = drinkService;
        }

        public async Task<IActionResult> MenuList()
        {
            var menus = await _menuService.GetAllMenus();
            var mappedMenus = _mapper.Map<List<MenuViewModel>>(menus);
            return View(mappedMenus);
        }

        [HttpGet]
        public async Task<IActionResult> GetGarnitures()
        {
            var garnitures = await _garnitureService.GetAllGarnitures();
            return Json(garnitures);
        }

        [HttpGet]
        public async Task<IActionResult> GetDrinks()
        {
            var drinks = await _drinkService.GetAllDrinks();
            return Json(drinks);
        }
    }
}
