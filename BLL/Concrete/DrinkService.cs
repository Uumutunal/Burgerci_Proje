using AutoMapper;
using BLL.Abstract;
using BLL.DTOs;
using Burgerci_Proje.Entities;
using DAL.AbstractRepositories;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class DrinkService : IDrinkService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Drink> _drinkRepository;
        public DrinkService(IRepository<Drink> drinkRepository, IMapper mapper)
        {
            _drinkRepository = drinkRepository;
            _mapper = mapper;
        }
        public async Task CreateDrink(DrinkDto drinkDto)
        {
            var drink = _mapper.Map<Drink>(drinkDto);
            await _drinkRepository.AddAsync(drink);
        }

        public async Task DeleteDrink(Guid drinkId)
        {
            await _drinkRepository.DeleteAsync(drinkId);
        }

        public async Task<List<DrinkDto>> GetAllDrinks()
        {
            var drinks = await _drinkRepository.GetAllAsync();
            var mappedDrinks = _mapper.Map<List<DrinkDto>>(drinks);
            return mappedDrinks;
        }

        public async Task UpdateDrink(DrinkDto drinkDto)
        {
            var drink = _mapper.Map<Drink>(drinkDto);
            await _drinkRepository.UpdateAsync(drink);
        }
        public async Task<DrinkDto> GetDrinkById(Guid id)
        {
            var drink = await _drinkRepository.GetByIdAsync(id);
            return _mapper.Map<DrinkDto>(drink);
        }
    }
}
