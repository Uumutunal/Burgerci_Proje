using AutoMapper;
using BLL.Abstract;
using BLL.Concrete;
using BLL.DTOs;
using Burgerci_Proje.Models;
using Microsoft.AspNetCore.Mvc;

namespace Burgerci_Proje.Controllers
{
    public class HamburgerController : Controller
    {
        private readonly IHamburgerService _hamburgerService;
        private readonly IGarnitureService _garnitureService;
        private readonly IMapper _mapper;

        public HamburgerController(IHamburgerService hamburgerService, IGarnitureService garnitureService, IMapper mapper)
        {
            _hamburgerService = hamburgerService;
            _garnitureService = garnitureService;
            _mapper = mapper;
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

                    hamburgerViewModel.ImageUrl = fileName;
                }
                var hamburgerDto = _mapper.Map<HamburgerDto>(hamburgerViewModel);
                var selectedGarnitureIds = hamburgerViewModel.SelectedGarnitureIds;
                var garnitureDtos = await _garnitureService.GetGarnituresByIds(selectedGarnitureIds);
                await _hamburgerService.CreateHamburger(hamburgerDto, garnitureDtos);
                return RedirectToAction("GarnitureList" , "Garniture");
            }
            var garnitures = await _garnitureService.GetAllGarnitures();
            ViewBag.Garnitures = _mapper.Map<List<GarnitureViewModel>>(garnitures);
            return View(hamburgerViewModel);
        }
    }

}
