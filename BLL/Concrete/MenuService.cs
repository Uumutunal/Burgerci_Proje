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
        public async Task CreateMenu(MenuDto menuDto, HamburgerDto hamburgerDto, DrinkDto drinkDto, ExtraDto extraDto)
        {
            // MenuDto, HamburgerDto, DrinkDto ve ExtraDto nesnelerini kullanarak iþlemleri gerçekleþtir
            var menu = _mapper.Map<Menu>(menuDto);

            if (hamburgerDto != null)
            {
                var hamburger = _mapper.Map<Hamburger>(hamburgerDto);
                // Hamburger'ý iþleyin (örneðin, iliþkilendirerek)
            }

            if (drinkDto != null)
            {
                var drink = _mapper.Map<Drink>(drinkDto);
                // Drink'i iþleyin (örneðin, iliþkilendirerek)
            }

            if (extraDto != null)
            {
                var extra = _mapper.Map<Extra>(extraDto);
                // Extra'yý iþleyin (örneðin, iliþkilendirerek)
            }

            // Menü ve diðer nesneleri veritabanýna kaydedin
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

        public async Task<List<MenuDto>> GetMenuWithIncludes(string[] includes)
        {

            var menus = await _menuRepository.GetAllWithIncludes(includes);

            var menuDtos = _mapper.Map<List<MenuDto>>(menus.ToList());

            return menuDtos;
        }
    }
}
