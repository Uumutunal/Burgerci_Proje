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

            ViewBag.IsAdmin = HttpContext.Session.GetString("IsAdmin");


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

        [HttpGet]
        public async Task<IActionResult> EditMenu(Guid id)
        {
            var menu = await _menuService.GetMenuById(id);
            if (menu == null)
            {
                return NotFound();
            }

            var menuViewModel = _mapper.Map<MenuViewModel>(menu);

            // Assuming you want to pass lists of hamburgers, drinks, and extras for dropdowns
            ViewBag.AllHamburgers = await GetHamburgers();
            ViewBag.AllDrinks = await GetDrinks();
            ViewBag.AllExtras = await GetExtras();

            return View(menuViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditMenu(MenuViewModel menuViewModel)
        {

            // Handle the file upload if a new photo is provided
            if (menuViewModel.PhotoUrl != null)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                var uniqueFileName = $"{Guid.NewGuid()}_{menuViewModel.PhotoUrl.FileName}";
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await menuViewModel.PhotoUrl.CopyToAsync(fileStream);
                }

                menuViewModel.Photo = $"/images/{uniqueFileName}";
            }

            var menu = _mapper.Map<MenuDto>(menuViewModel);

            await _menuService.UpdateMenu(menu);

            return RedirectToAction("MenuList");
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var menuDto = await _menuService.GetMenuById(id);
            if (menuDto == null)
            {
                return NotFound();
            }

            // Menüye ait hamburgeri al
            var hamburger = await _hamburgerService.GetHamburgerByIdAsync(menuDto.HamburgerId);

            // Menüye ait içecek ve ekstra verilerini al
            var drink = await _drinkService.GetDrinkById(menuDto.DrinkId);
            var extra = await _extraService.GetExtraById(menuDto.ExtraId);

            // ViewBag'lere ata
            ViewBag.HamburgerName = hamburger?.Name;
            ViewBag.DrinkName = drink?.Name;
            ViewBag.ExtraName = extra?.Name;

            // Menü ViewModel'ini oluþtur ve View'a geç
            var menuViewModel = _mapper.Map<MenuViewModel>(menuDto);

            return View(menuViewModel);
        }


        [HttpGet]
        public async Task<IActionResult> DeleteMenu(Guid id)
        {
            await _menuService.DeleteMenu(id);
            return RedirectToAction("MenuList");
        }

    }
}
