using AutoMapper;
using BLL.Abstract;
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

        public async Task<IActionResult> Index()
        {
            var role = HttpContext.Session.GetString("IsAdmin");
            if (role != "True")
            {
                ViewBag.ErrorMessage = "You do not have permission to view this page.";
                return View();
            }
            var garnitures = await _garnitureService.GetAllGarnitures();
            var mappedGarnitures = _mapper.Map<List<GarnitureViewModel>>(garnitures);
            return View(mappedGarnitures);
        }
    }
}
