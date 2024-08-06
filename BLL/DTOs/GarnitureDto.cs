using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class GarnitureDto : BaseDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public List<HamburgerGarnitureDto> HamburgerGarnitureDtos { get; set; }
    }
}
