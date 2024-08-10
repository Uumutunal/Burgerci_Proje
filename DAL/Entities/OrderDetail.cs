using Burgerci_Proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class OrderDetail : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Guid? MenuId { get; set; }
        public Guid? HamburgerId { get; set; }
        public Guid? DrinkId { get; set; }
        public Guid? ExtraId { get; set; }
        public int Quantity { get; set; }
        public string? Size { get; set; }
        public double Price { get; set; }
        public Order Order { get; set; }
        public Menu Menu {get; set;}
        public Hamburger Hamburger { get; set;}
        public Drink Drink { get; set;}
        public Extra Extra { get; set;}
    }
}
