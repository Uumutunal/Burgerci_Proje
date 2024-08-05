using AutoMapper;
using BLL.Abstract;
using BLL.DTOs;
using Burgerci_Proje.Entities;
using DAL.AbstractRepositories;
using DAL.Entities;

namespace BLL.Concrete
{
    public class MenuService : IMenuService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Menu> _menuRepository;
        public MenuService(IRepository<Menu> menuRepository, IMapper mapper)
        {
            _menuRepository = menuRepository;
            _mapper = mapper;
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
            var garnitureDtos = _mapper.Map<List<MenuDto>>(menus);
            return garnitureDtos;
        }
    }
}
