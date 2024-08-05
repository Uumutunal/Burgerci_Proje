using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dtos
{
    public class GarnitureDto :BaseDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<BurgerGarnitureDto> BurgerGarnitureDtos { get; set; }
    }
}
