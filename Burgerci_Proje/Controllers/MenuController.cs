using AutoMapper;
using BLL.Abstract;
using BLL.Concrete;
using BLL.DTOs;
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

        public MenuController(IMapper mapper, IMenuService menuService, IGarnitureService garnitureService, IDrinkService drinkService,IHamburgerService hamburgerService, IExtraService extraService)
        {
            _mapper = mapper;
            _menuService = menuService;
            _garnitureService = garnitureService;
            _drinkService = drinkService;
            _hamburgerService = hamburgerService;
            _extraService = extraService;
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

            return RedirectToAction("Index", "Order");
        }
        public async Task<IActionResult> CreateMenu()
        {
            ViewBag.AllHamburgers = await GetHamburgers();
            ViewBag.AllDrinks = await GetDrinks();
            ViewBag.AllExtras = await GetExtras();
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> CreateMenu(MenuViewModel menuViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Fotoðraf yükleme iþlemi
                    if (menuViewModel.PhotoUrl != null)
                    {
                        var fileName = Path.GetFileName(menuViewModel.PhotoUrl.FileName);
                        var filePath = Path.Combine("wwwroot", "Images", fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await menuViewModel.PhotoUrl.CopyToAsync(stream);
                        }

                        menuViewModel.Photo = fileName;
                    }

                    // DTO'larý almak
                    var hamburgerDto = await _hamburgerService.GetHamburgerByIdAsync(menuViewModel.HamburgerId);
                    var drinkDto = await _drinkService.GetDrinkById(menuViewModel.DrinkId);
                    var extraDto = await _extraService.GetExtraById(menuViewModel.ExtraId);

                    // Menü DTO'suna verileri atama
                    var menuDto = _mapper.Map<MenuDto>(menuViewModel);

                    // Menü ve iliþkili öðeleri kaydetme
                    await _menuService.CreateMenu(menuDto, hamburgerDto, drinkDto, extraDto);

                    return RedirectToAction("MenuList");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred while creating the menu.");
                }
            }

            // Formu yeniden göster
            ViewBag.AllHamburgers = await GetHamburgers();
            ViewBag.AllDrinks = await GetDrinks();
            ViewBag.AllExtras = await GetExtras();
            return View(menuViewModel);
        }




        public async Task<IActionResult> MenuList()
        {
            var menus = await _menuService.GetAllMenus();
            var mappedMenus = _mapper.Map<List<MenuViewModel>>(menus);
            return View(mappedMenus);
        }
        public async Task<List<HamburgerViewModel>> GetHamburgers()
        {
            var hamburgers = await _hamburgerService.GetAllHamburgers();
            return _mapper.Map<List<HamburgerViewModel>>(hamburgers);
        }

        public async Task<List<DrinkViewModel>> GetDrinks()
        {
            var drinks = await _drinkService.GetAllDrinks();
            return _mapper.Map<List<DrinkViewModel>>(drinks);
        }

        public async Task<List<ExtraViewModel>> GetExtras()
        {
            var extras = await _extraService.GetAllExtra();
            return _mapper.Map<List<ExtraViewModel>>(extras);
        }



    }
}
