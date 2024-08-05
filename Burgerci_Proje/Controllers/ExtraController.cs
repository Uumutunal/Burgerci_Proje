using AutoMapper;
using BLL.Abstract;
using BLL.Concrete;
using BLL.DTOs;
using Burgerci_Proje.Models;
using Microsoft.AspNetCore.Mvc;

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
            return View(mappedExtras);
        }

        [HttpGet]
        public async Task<IActionResult> CreateExtra()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateExtra(ExtraViewModel extraViewModel)
        {
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
    }
}
