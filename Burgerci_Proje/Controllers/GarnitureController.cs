using AutoMapper;
using BLL.Abstract;
using BLL.DTOs;
using Burgerci_Proje.Models;
using Microsoft.AspNetCore.Mvc;

namespace Burgerci_Proje.Controllers
{
    public class GarnitureController : Controller
    {
        private readonly IGarnitureService _garnitureService;
        private readonly IMapper _mapper;
        public GarnitureController(IGarnitureService garnitureService, IMapper mapper)
        {
            _garnitureService = garnitureService;
            _mapper = mapper;
        }

        public async Task<IActionResult> GarnitureList()
        {
            /*
             * Şimdilik böyle kalsın lazım olursa açarız.
             * 
            var role = HttpContext.Session.GetString("IsAdmin");
            if (role != "True")
            {
                ViewBag.ErrorMessage = "You do not have permission to view this page.";
                return View();
            }
            */

            ViewBag.IsAdmin = HttpContext.Session.GetString("IsAdmin");


            var garnitures = await _garnitureService.GetAllGarnitures();
            var mappedGarnitures = _mapper.Map<List<GarnitureViewModel>>(garnitures);
            return View(mappedGarnitures);
        }

        [HttpGet]
        public async Task<IActionResult> CreateGarniture()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateGarniture(GarnitureViewModel garnitureViewModel)
        {
            if (ModelState.IsValid)
            {
                var garnitureDto = _mapper.Map<GarnitureDto>(garnitureViewModel);
                await _garnitureService.CreateGarniture(garnitureDto);
                return RedirectToAction("GarnitureList");
            }
            return View(garnitureViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteGarniture(Guid id)
        {
            await _garnitureService.DeleteGarniture(id);
            return RedirectToAction("GarnitureList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateGarniture(Guid id)
        {
            var garnitures = await _garnitureService.GetAllGarnitures();
            var mappedGarnitures = _mapper.Map<List<GarnitureViewModel>>(garnitures);
            var garnitureToUpdate = mappedGarnitures.FirstOrDefault(x => x.Id == id);
            return View(garnitureToUpdate);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateGarniture(GarnitureViewModel garnitureViewModel)
        {
            if (ModelState.IsValid)
            {
                var garnitureDto = _mapper.Map<GarnitureDto>(garnitureViewModel);
                await _garnitureService.UpdateGarniture(garnitureDto);
                return RedirectToAction("GarnitureList");
            }
            return View(garnitureViewModel);
        }
    }
}
