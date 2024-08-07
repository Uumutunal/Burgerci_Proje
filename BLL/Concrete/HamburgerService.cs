using AutoMapper;
using BLL.Abstract;
using BLL.DTOs;
using Burgerci_Proje.Entities;
using DAL.AbstractRepositories;
using DAL.Data;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class HamburgerService : IHamburgerService
    {
        private readonly IRepository<Hamburger> _hamburgerRepository;
        private readonly IRepository<HamburgerGarniture> _hamburgerGarnitureRepository;
        private readonly IMapper _mapper;

        public HamburgerService(IRepository<Hamburger> hamburgerRepository, IRepository<HamburgerGarniture> hamburgerGarnitureRepository, IMapper mapper)
        {
            _hamburgerRepository = hamburgerRepository;
            _hamburgerGarnitureRepository = hamburgerGarnitureRepository;
            _mapper = mapper;
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

        public Task DeleteHamburger(Guid hamburgerId)
        {
            throw new NotImplementedException();
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

        public Task UpdateHamburger(HamburgerDto hamburgerDto, List<GarnitureDto> garnitureDtos)
        {
            throw new NotImplementedException();
        }
    }

}
