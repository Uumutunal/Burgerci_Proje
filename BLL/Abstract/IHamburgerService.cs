using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IHamburgerService
    {
        Task<List<HamburgerDto>> GetAllHamburgers();
        Task CreateHamburger(HamburgerDto hamburgerDto, List<GarnitureDto> garnitureDtos);
        Task DeleteHamburger(Guid hamburgerId);
       // Task UpdateHamburger(HamburgerDto hamburgerDto, List<GarnitureDto> garnitureDtos);
    }
}
