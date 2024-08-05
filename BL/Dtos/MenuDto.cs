using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dtos
{
    public class MenuDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public Guid HamburgerId { get; set; }
        public Guid DrinkId { get; set; }
        public Guid ExtraId { get; set; }
        public HamburgerDto Hamburger { get; set; }
        public DrinkDto Drink { get; set; }
        public ExtraDto Extra { get; set; }
    }
}
