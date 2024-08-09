using BLL.Abstract;
using Burgerci_Proje.Models;
using Microsoft.AspNetCore.Mvc;

namespace Burgerci_Proje.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDrinkService _drinkService;
        private readonly IExtraService _extraService;
        private readonly IHamburgerService _hamburgerService;

        public HomeController(IDrinkService drinkService, IExtraService extraService, IHamburgerService hamburgerService)
        {
            _drinkService = drinkService;
            _extraService = extraService;
            _hamburgerService = hamburgerService;
        }
        public async Task<IActionResult> Index(string category = "All")
        {
            var model = new MenuItemsViewModel
            {
                Drinks = (await _drinkService.GetAllDrinks()).Select(d => new DrinkViewModel
                {
                    Name = d.Name,
                    Price = d.Price,
                    Quantity = d.Quantity,
                    Size = d.Size,
                    Photo = d.ImageUrl
                }).ToList(),
                Extras = (await _extraService.GetAllExtra()).Select(e => new ExtraViewModel
                {
                    Name = e.Name,
                    Description = e.Description,
                    Price = e.Price,
                    Quantity = e.Quantity,
                    Size = e.Size,
                    Photo = e.ImageUrl
                }).ToList(),
                Hamburgers = (await _hamburgerService.GetAllHamburgers()).Select(h => new HamburgerViewModel
                {
                    Name = h.Name,
                    Description = h.Description,
                    Price = h.Price,
                    SelectedGarnitureIds = h.SelectedGarnitureIds,
                    Quantity = h.Quantity,
                    Size = h.Size,
                    Photo = h.ImageUrl
                }).ToList(),

                SelectedCategory = category
            };

            switch (category)
            {
                case "Hamburger":
                    model.Drinks = new List<DrinkViewModel>();
                    model.Extras = new List<ExtraViewModel>();
                    break;
                case "Drink":
                    model.Hamburgers = new List<HamburgerViewModel>();
                    model.Extras = new List<ExtraViewModel>();
                    break;
                case "Extra":
                    model.Hamburgers = new List<HamburgerViewModel>();
                    model.Drinks = new List<DrinkViewModel>();
                    break;
                case "All":
                default:
                    break;
            }

            return PartialView(model);
        }


    }
}
