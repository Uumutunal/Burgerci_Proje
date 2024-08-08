using AutoMapper;
using BLL.Abstract;
using BLL.Concrete;
using BLL.DTOs;
using Burgerci_Proje.Models;
using Microsoft.AspNetCore.Mvc;

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

            Guid.TryParse(HttpContext.Session.GetString("UserId"), out Guid userGuid);
            var user = await _userService.GetUserById(userGuid);
            var userMapped = _mapper.Map<UserViewModel>(user);
            ViewBag.IsAdmin = userMapped.IsAdmin;

            return View(mappedDrinks);

        }

        [HttpGet]
        public async Task<IActionResult> CreateDrink() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDrink(DrinkViewModel drinkViewModel)
        {
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
    }
}
