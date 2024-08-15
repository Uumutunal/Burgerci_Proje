using AutoMapper;
using BLL.Abstract;
using BLL.Concrete;
using BLL.DTOs;
using Burgerci_Proje.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Burgerci_Proje.Controllers
{
    public class ExtraController : Controller
    {
        private readonly IExtraService _extraService;
        private readonly IMapper _mapper;
        public ExtraController(IExtraService extraService, IMapper mapper)
        {
            _extraService = extraService;
            _mapper = mapper;
        }

        public async Task<IActionResult> ExtraList()
        {
            var extras = await _extraService.GetAllExtra();
            var mappedExtras = _mapper.Map<List<ExtraViewModel>>(extras);
            ViewBag.IsAdmin = HttpContext.Session.GetString("IsAdmin");

            return View(mappedExtras);
        }

        [HttpGet]
        public async Task<IActionResult> CreateExtra()
        {
            ViewBag.IsAdmin = HttpContext.Session.GetString("IsAdmin");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateExtra(ExtraViewModel extraViewModel)
        {
            if (extraViewModel.PhotoUrl != null)
            {
                var fileName = Path.GetFileName(extraViewModel.PhotoUrl.FileName);
                var filePath = Path.Combine("wwwroot", "Images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await extraViewModel.PhotoUrl.CopyToAsync(stream);
                }

                extraViewModel.Photo = fileName;
            }
            var extraDto = _mapper.Map<ExtraDto>(extraViewModel);
            await _extraService.CreateExtra(extraDto);
            return RedirectToAction("ExtraList");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteExtra(Guid id)
        {
            await _extraService.DeleteExtra(id);
            return RedirectToAction("ExtraList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateExtra(Guid id)
        {
            ViewBag.IsAdmin = HttpContext.Session.GetString("IsAdmin");
            var extras = await _extraService.GetAllExtra();
            var mappedExtras = _mapper.Map<List<ExtraViewModel>>(extras);
            var extraToUpdate = mappedExtras.FirstOrDefault(x => x.Id == id);
            return View(extraToUpdate);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateExtra(ExtraViewModel extraViewModel)
        {
            var extraDto = _mapper.Map<ExtraDto>(extraViewModel);
            await _extraService.UpdateExtra(extraDto);
            return RedirectToAction("ExtraList");
        }

        [HttpPost]
        public async Task<IActionResult> AddToBasketExtra(ExtraViewModel extraViewModel)
        {

            //var menu = await _menuService.GetMenuWithIncludes(new[] { "Hamburger", "Drink", "Extra" });

            TempData["ExtraData"] = JsonConvert.SerializeObject(extraViewModel);

            return RedirectToAction("OrderExtra", "Order");
        }
    }
}
