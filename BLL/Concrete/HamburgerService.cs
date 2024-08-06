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
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public HamburgerService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateHamburger(HamburgerDto hamburgerDto, List<GarnitureDto> garnitureDtos)
        {
            var hamburger = _mapper.Map<Hamburger>(hamburgerDto);
            _context.Hamburgers.Add(hamburger);

            foreach (var garnitureDto in garnitureDtos)
            {
                var hamburgerGarniture = new HamburgerGarniture
                {
                    Hamburger = hamburger,
                    GarnitureId = garnitureDto.Id
                };

                _context.HamburgerGarnitures.Add(hamburgerGarniture);
            }

            await _context.SaveChangesAsync();
        }

        public Task DeleteHamburger(Guid hamburgerId)
        {
            throw new NotImplementedException();
        }

        public Task<List<HamburgerDto>> GetAllHamburgers()
        {
            throw new NotImplementedException();
        }

        public Task UpdateHamburger(HamburgerDto hamburgerDto, List<GarnitureDto> garnitureDtos)
        {
            throw new NotImplementedException();
        }
    }

}
