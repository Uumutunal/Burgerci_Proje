using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dtos
{
    public class OrderDetailDto : BaseDto
    {
        public Guid OrderId { get; set; }
        public Guid MenuId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public OrderDto OrderDto { get; set; }
        public MenuDto MenuDto { get; set; }
    }
}
