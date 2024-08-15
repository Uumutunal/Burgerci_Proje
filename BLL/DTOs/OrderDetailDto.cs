using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class OrderDetailDto : BaseDto
    {
        public Guid OrderId { get; set; }
        public Guid? MenuId { get; set; }
        public Guid? HamburgerId { get; set; }
        public Guid? DrinkId { get; set; }
        public Guid? ExtraId { get; set; }
        public int Quantity { get; set; }
        public string? Size { get; set; }
        public double Price { get; set; }
        public OrderDto OrderDto { get; set; }
        public MenuDto MenuDto { get; set; }
        public HamburgerDto HamburgerDto { get; set; }
        public DrinkDto DrinkDto { get; set; }
        public ExtraDto ExtraDto { get; set; }
    }
}
