using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IExtraService
    {
        Task<List<ExtraDto>> GetAllExtra();
        Task CreateExtra(ExtraDto extraDto);
        Task DeleteExtra(Guid extraId);
        Task UpdateExtra(ExtraDto extraDto);
        Task<ExtraDto> GetExtraById(Guid id);

    }
}
