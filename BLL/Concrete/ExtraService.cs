using AutoMapper;
using BLL.Abstract;
using BLL.DTOs;
using Burgerci_Proje.Entities;
using DAL.AbstractRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class ExtraService : IExtraService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Extra> _extraRepository;
        public ExtraService(IRepository<Extra> extraRepository, IMapper mapper)
        {
            _extraRepository = extraRepository;
            _mapper = mapper;
        }
        public async Task CreateExtra(ExtraDto extraDto)
        {
            var extra = _mapper.Map<Extra>(extraDto);
            await _extraRepository.AddAsync(extra);
        }

        public async Task DeleteExtra(Guid extraId)
        {
            await _extraRepository.DeleteAsync(extraId);
        }

        public async Task<List<ExtraDto>> GetAllExtra()
        {
            var extras = await _extraRepository.GetAllAsync();
            var mappedExtras = _mapper.Map<List<ExtraDto>>(extras);
            return mappedExtras;
        }

        public async Task UpdateExtra(ExtraDto extraDto)
        {
            var extra = _mapper.Map<Extra>(extraDto);
            await _extraRepository.UpdateAsync(extra);
        }
        public async Task<ExtraDto> GetExtraById(Guid id)
        {
            var extra = await _extraRepository.GetByIdAsync(id);
            return _mapper.Map<ExtraDto>(extra);
        }
    }
}
