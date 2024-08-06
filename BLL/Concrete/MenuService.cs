using AutoMapper;
using BLL.Abstract;
using BLL.DTOs;
using Burgerci_Proje.Entities;
using DAL.AbstractRepositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class MenuService : IMenuService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Menu> _menuRepository;

        public MenuService(IMapper mapper,IRepository<Menu> menuRepository)
        {
            this._mapper = mapper;
            _menuRepository = menuRepository;
        }
        public async Task CreateMenu(MenuDto menuDto)
        {
            var menu = _mapper.Map<Menu>(menuDto);
            await _menuRepository.AddAsync(menu);
        }

        public async Task DeleteMenu(Guid menuId)
        {
           await _menuRepository.DeleteAsync(menuId);
        }

        public async Task<List<MenuDto>> GetAllMenus()
        {
            var menus = await _menuRepository.GetAllAsync();
            var mappedMenus = _mapper.Map<List<MenuDto>>(menus);
            return mappedMenus;
        }

        public async Task UpdateMenu(MenuDto menuDto)
        {
            var menu = _mapper.Map<Menu>(menuDto);
            await _menuRepository.UpdateAsync(menu);
        }
    }
}
