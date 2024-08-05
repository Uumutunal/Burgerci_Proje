using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IDrinkService
    {
        Task<List<DrinkDto>> GetAllDrinks();
        Task CreateDrink(DrinkDto drinkDto);
        Task DeleteDrink(Guid drinkId);
        Task UpdateDrink(DrinkDto drinkDto);
    }
}
