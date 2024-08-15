using AutoMapper;
using BLL.Abstract;
using BLL.Concrete;
using BLL.DTOs;
using Burgerci_Proje.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Burgerci_Proje.Controllers
{
    public class DrinkController : Controller
    {
        private readonly IDrinkService _drinkService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public DrinkController(IDrinkService drinkService, IMapper mapper, IUserService userService)
        {
            _drinkService = drinkService;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<IActionResult> DrinkList()
        {
            var drinks = await _drinkService.GetAllDrinks();
            var mappedDrinks = _mapper.Map<List<DrinkViewModel>>(drinks);

            ViewBag.IsAdmin = HttpContext.Session.GetString("IsAdmin");

            return View(mappedDrinks);

        }

        [HttpGet]
        public async Task<IActionResult> CreateDrink() 
        {
            ViewBag.IsAdmin = HttpContext.Session.GetString("IsAdmin");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDrink(DrinkViewModel drinkViewModel)
        {
            ViewBag.IsAdmin = HttpContext.Session.GetString("IsAdmin");

            var drinkDto = _mapper.Map<DrinkDto>(drinkViewModel);
            await _drinkService.CreateDrink(drinkDto);
            return RedirectToAction("DrinkList");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteDrink(Guid id)
        {
            await _drinkService.DeleteDrink(id);
            return RedirectToAction("DrinkList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateDrink(Guid id)
        {
            ViewBag.IsAdmin = HttpContext.Session.GetString("IsAdmin");

            var drinks = await _drinkService.GetAllDrinks();
            var mappedDrinks = _mapper.Map<List<DrinkViewModel>>(drinks);
            var drinkToUpdate = mappedDrinks.FirstOrDefault(x => x.Id == id);
            return View(drinkToUpdate);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDrink(DrinkViewModel drinkViewModel)
        {
            var drinkDto = _mapper.Map<DrinkDto>(drinkViewModel);
            await _drinkService.UpdateDrink(drinkDto);
            return RedirectToAction("DrinkList");
        }

        [HttpPost]
        public async Task<IActionResult> AddToBasketDrink(DrinkViewModel drinkViewModel)
        {

            //var menu = await _menuService.GetMenuWithIncludes(new[] { "Hamburger", "Drink", "Extra" });

            TempData["DrinkData"] = JsonConvert.SerializeObject(drinkViewModel);

            return RedirectToAction("OrderDrink", "Order");
        }
    }
}
