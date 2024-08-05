using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dtos
{
    public class BurgerGarnitureDto : BaseDto
    {
        public Guid BurgerId { get; set; }
        public Guid IngredientId { get; set; }
        public HamburgerDto BurgerDto { get; set; }
        public GarnitureDto IngredientDto { get; set; }
    }
}
