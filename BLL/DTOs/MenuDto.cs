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
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public Guid HamburgerId { get; set; }
        public Guid DrinkId { get; set; }
        public Guid SnackId { get; set; }
        public HamburgerDto HamburgerDto { get; set; }
        public DrinkDto DrinkDto { get; set; }
        public ExtraDto ExtraDto { get; set; }
    }
}
