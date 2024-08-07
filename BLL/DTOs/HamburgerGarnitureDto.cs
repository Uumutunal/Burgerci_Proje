using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class HamburgerGarnitureDto : BaseDto
    {
        public Guid HamburgerId { get; set; }
        public Guid GarnitureId { get; set; }
        public HamburgerDto HamburgerDto { get; set; }
        public GarnitureDto GarnitureDto { get; set; }
    }
}
