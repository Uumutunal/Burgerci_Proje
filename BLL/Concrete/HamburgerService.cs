using AutoMapper;
using BLL.Abstract;
using BLL.DTOs;
using Burgerci_Proje.Entities;
using DAL.AbstractRepositories;
using DAL.ConcreteRepository;
using DAL.Data;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class HamburgerService : IHamburgerService
    {
        private readonly IRepository<Hamburger> _hamburgerRepository;
        private readonly IRepository<HamburgerGarniture> _hamburgerGarnitureRepository;
        private readonly IMapper _mapper;
        private readonly IRepository<Garniture> _garnitureRepository;

        public HamburgerService(IRepository<Hamburger> hamburgerRepository, IRepository<HamburgerGarniture> hamburgerGarnitureRepository, IMapper mapper, IRepository<Garniture> garnitureRepository)
        {
            _hamburgerRepository = hamburgerRepository;
            _hamburgerGarnitureRepository = hamburgerGarnitureRepository;
            _mapper = mapper;
            _garnitureRepository = garnitureRepository;
        }

        public async Task CreateHamburger(HamburgerDto hamburgerDto, List<GarnitureDto> garnitureDtos)
        {
            var hamburger = _mapper.Map<Hamburger>(hamburgerDto);
            await _hamburgerRepository.AddAsync(hamburger);

            foreach (var garnitureDto in garnitureDtos)
            {
                var hamburgerGarniture = new HamburgerGarniture
                {
                    Hamburger = hamburger,
                    GarnitureId = garnitureDto.Id
                };

                await _hamburgerGarnitureRepository.AddAsync(hamburgerGarniture);
            }
        }

        public async Task DeleteHamburger(Guid hamburgerId)
        {
           await _hamburgerRepository.DeleteAsync(hamburgerId);
        }

        public async Task<List<HamburgerDto>> GetAllHamburgers()
        {
            var hamburgers = await _hamburgerRepository.GetAllAsync();
            var mappedHamburgers = _mapper.Map<List<HamburgerDto>>(hamburgers);
            // var garnitures = await _hamburgerGarnitureRepository.GetAllAsync();
            //// _haöburgergarniture repo dan alıp yap
            //TempData["Garnitures"] = _mapper.Map<List<HamburgerGarniture>>(garnitures);
            return mappedHamburgers;
          
        }

        public async Task<HamburgerDto> GetHamburgerByIdAsync(Guid id)
        {
            var hamburger = await _hamburgerRepository.GetByIdAsync(id);
            
            return _mapper.Map<HamburgerDto>(hamburger);
        }

        public async Task UpdateHamburgerAsync(HamburgerDto hamburgerDto)
        {
            var hamburger = _mapper.Map<Hamburger>(hamburgerDto);

            await _hamburgerRepository.UpdateAsync(hamburger);
        }
     


    }

}
