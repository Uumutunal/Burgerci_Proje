using AutoMapper;
using BLL.Abstract;
using BLL.Concrete;
using BLL.DTOs;
using Burgerci_Proje.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Burgerci_Proje.Controllers
{
    public class HamburgerController : Controller
    {
        private readonly IHamburgerService _hamburgerService;
        private readonly IGarnitureService _garnitureService;
        private readonly IHamburgerGarnitureService _hamburgerGarnitureService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public HamburgerController(IHamburgerService hamburgerService, IGarnitureService garnitureService,IHamburgerGarnitureService hamburgerGarnitureService, IMapper mapper, IUserService userService)
        {
            _hamburgerService = hamburgerService;
            _garnitureService = garnitureService;
            _hamburgerGarnitureService = hamburgerGarnitureService;
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> CreateHamburger()
        {
            var garnitures = await _garnitureService.GetAllGarnitures();
            ViewBag.Garnitures = _mapper.Map<List<GarnitureViewModel>>(garnitures);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateHamburger(HamburgerViewModel hamburgerViewModel)
        {
            if (hamburgerViewModel.PhotoUrl != null)
            {
                var fileName = Path.GetFileName(hamburgerViewModel.PhotoUrl.FileName);
                var filePath = Path.Combine("wwwroot", "Images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await hamburgerViewModel.PhotoUrl.CopyToAsync(stream);
                }

                hamburgerViewModel.Photo = fileName;
            }
            if (ModelState.IsValid)
            {
            
                var hamburgerDto = _mapper.Map<HamburgerDto>(hamburgerViewModel);
                var selectedGarnitureIds = hamburgerViewModel.SelectedGarnitureIds;
                var garnitureDtos = await _garnitureService.GetGarnituresByIds(selectedGarnitureIds);
                await _hamburgerService.CreateHamburger(hamburgerDto, garnitureDtos);
                return RedirectToAction("ListHamburgers");
            }
            var garnitures = await _garnitureService.GetAllGarnitures();
            ViewBag.Garnitures = _mapper.Map<List<GarnitureViewModel>>(garnitures);
            return View(hamburgerViewModel);
        }

        public async Task<IActionResult> ListHamburgers()
        {
            var hamburgers = await _hamburgerService.GetAllHamburgers();
            var mappedHamburgers = _mapper.Map<List<HamburgerViewModel>>(hamburgers);

            var garnitures = await _garnitureService.GetAllGarnitures();

            var mappedGarnitures = _mapper.Map<List<GarnitureViewModel>>(garnitures);

            ViewBag.IsAdmin = HttpContext.Session.GetString("IsAdmin");

            ViewBag.Garnitures = mappedGarnitures;
            return View(mappedHamburgers);
        }

        [HttpGet]
        public async Task<IActionResult> EditHamburger(Guid id)
        {
            var hamburger = await _hamburgerService.GetHamburgerByIdAsync(id);
            if (hamburger == null)
            {
                return NotFound();
            }

            var hamburgerViewModel = _mapper.Map<HamburgerViewModel>(hamburger);
            var garnitures = await _garnitureService.GetAllGarnitures();
            ViewBag.Garnitures = _mapper.Map<List<GarnitureViewModel>>(garnitures);

            return View(hamburgerViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditHamburger(HamburgerViewModel hamburgerViewModel)
        {
            if (ModelState.IsValid)
            {
                if (hamburgerViewModel.PhotoUrl != null)
                {
                    var fileName = Path.GetFileName(hamburgerViewModel.PhotoUrl.FileName);
                    var filePath = Path.Combine("wwwroot", "Images", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await hamburgerViewModel.PhotoUrl.CopyToAsync(stream);
                    }

                    hamburgerViewModel.Photo = fileName;
                }

                var hamburgerDto = _mapper.Map<HamburgerDto>(hamburgerViewModel);
                //var garnitureDtos = await _garnitureService.GetGarnituresByIds(hamburgerViewModel.SelectedGarnitureIds); ---> kaydetmezse çözüm bul
                await _hamburgerService.UpdateHamburgerAsync(hamburgerDto);
                return RedirectToAction("ListHamburgers");
            }

            var garnitures = await _garnitureService.GetAllGarnitures();
            ViewBag.Garnitures = _mapper.Map<List<GarnitureViewModel>>(garnitures);
            return View(hamburgerViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteHamburger(Guid id)
        {
            await _hamburgerService.DeleteHamburger(id);
            return RedirectToAction("ListHamburgers");
        }


        [HttpPost]
        public async Task<IActionResult> AddToBasketHamburger(HamburgerViewModel hamburgerViewModel)
        {

            //var menu = await _menuService.GetMenuWithIncludes(new[] { "Hamburger", "Drink", "Extra" });

            TempData["HamburgerData"] = JsonConvert.SerializeObject(hamburgerViewModel);

            return RedirectToAction("OrderHamburger", "Order");
        }

    }

}
