using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IMenuService
    {
        Task<List<MenuDto>> GetAllMenus();
        Task CreateMenu(MenuDto menuDto);
        Task DeleteMenu(Guid menuId);
        Task<List<MenuDto>> GetMenuWithIncludes(string[] includes);
    }
}
