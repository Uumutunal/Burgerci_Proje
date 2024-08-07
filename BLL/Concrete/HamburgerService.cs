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

        public async Task UpdateHamburger(HamburgerDto hamburgerDto, List<GarnitureDto> garnitureDtos)
        {
            // Fetch existing hamburger from repository
            var existingHamburger = await _hamburgerRepository.GetByIdAsync(hamburgerDto.Id);
            if (existingHamburger == null)
            {
                throw new Exception("Hamburger not found");
            }

            // Update hamburger properties
            existingHamburger.Name = hamburgerDto.Name;
            existingHamburger.Description = hamburgerDto.Description;
            existingHamburger.Price = hamburgerDto.Price;
            existingHamburger.ImageUrl = hamburgerDto.ImageUrl;

            // Update garnitures
            var existingGarnitures = await _garnitureRepository.GetByHamburgerIdAsync(hamburgerDto.Id);
            var garnitureIds = garnitureDtos.Select(g => g.Id).ToList();

            // Remove garnitures that are no longer associated
            foreach (var garniture in existingGarnitures.Where(g => !garnitureIds.Contains(g.Id)).ToList())
            {
                existingHamburger.Garnitures.Remove(garniture);
            }

            // Add new garnitures
            foreach (var garnitureId in garnitureIds.Except(existingGarnitures.Select(g => g.Id)))
            {
                var garniture = await _garnitureRepository.GetByIdAsync(garnitureId);
                if (garniture != null)
                {
                    existingHamburger.Garnitures.Add(garniture);
                }
            }

            // Save changes to repository
            await _hamburgerRepository.UpdateAsync(existingHamburger);
        }
    }

}
