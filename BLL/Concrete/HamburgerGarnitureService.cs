using AutoMapper;
using BLL.Abstract;
using BLL.DTOs;
using DAL.AbstractRepositories;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class HamburgerGarnitureService : IHamburgerGarnitureService
    {
        private readonly IRepository<HamburgerGarniture> _hamburgerGarnitureRepository;
        private readonly IMapper _mapper;

        public HamburgerGarnitureService(IRepository<HamburgerGarniture> hamburgerGarnitureRepository, IMapper mapper )
        {
            _hamburgerGarnitureRepository = hamburgerGarnitureRepository;
            _mapper = mapper;
        }
        public async Task<List<HamburgerGarnitureDto>> GetAllHamburgerGarnitures()
        {
            var hamburgerGarnitures = await _hamburgerGarnitureRepository.GetAllAsync();
            var mappedHamburgerGarnitures =  _mapper.Map<List<HamburgerGarnitureDto>>( hamburgerGarnitures );
            return mappedHamburgerGarnitures;
        }
    }
}
