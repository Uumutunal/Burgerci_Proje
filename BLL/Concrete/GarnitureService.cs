using AutoMapper;
using BLL.Abstract;
using BLL.DTOs;
using DAL.AbstractRepositories;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BLL.Concrete
{
    public class GarnitureService : IGarnitureService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Garniture> _garnitureRepository;
        public GarnitureService(IRepository<Garniture> garnitureRepository, IMapper mapper)
        {
            _garnitureRepository = garnitureRepository;
            _mapper = mapper;
        }
        public async Task CreateGarniture(GarnitureDto garnitureDto)
        {
            var garniture = _mapper.Map<Garniture>(garnitureDto);
            await _garnitureRepository.AddAsync(garniture);
        }

        public async Task DeleteGarniture(Guid garnitureId)
        {
            await _garnitureRepository.DeleteAsync(garnitureId);
        }

        public async Task<List<GarnitureDto>> GetAllGarnitures()
        {
            var garnitures = await _garnitureRepository.GetAllAsync();
            var garnitureDtos = _mapper.Map<List<GarnitureDto>>(garnitures);
            return garnitureDtos;
        }

        public async Task UpdateGarniture(GarnitureDto garnitureDto)
        {
            var garniture = _mapper.Map<Garniture>(garnitureDto);
            await _garnitureRepository.UpdateAsync(garniture);
        }

        public async Task<List<GarnitureDto>> GetGarnituresByIds(List<Guid> ids)
        {
            var garnitures = await _garnitureRepository.GetAllAsync();
            var garnituresIds = garnitures.Where(g => ids.Contains(g.Id)).ToList();
            return _mapper.Map<List<GarnitureDto>>(garnituresIds);
        }
    }
}
