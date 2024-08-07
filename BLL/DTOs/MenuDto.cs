using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class MenuDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string? Photo { get; set; }
        public int Quantity { get; set; } = 1;
        public Guid HamburgerId { get; set; }
        public Guid DrinkId { get; set; }
        public Guid ExtraId { get; set; }
        public HamburgerDto HamburgerDto { get; set; }
        public DrinkDto DrinkDto { get; set; }
        public ExtraDto ExtraDto { get; set; }
    }
}
