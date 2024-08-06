using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IGarnitureService
    {
        Task<List<GarnitureDto>> GetAllGarnitures();
        Task CreateGarniture(GarnitureDto garnitureDto);
        Task DeleteGarniture(Guid garnitureId);
        Task UpdateGarniture(GarnitureDto garnitureDto);
    }
}
