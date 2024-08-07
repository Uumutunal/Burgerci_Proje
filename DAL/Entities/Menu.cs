using DAL.Entities;
using System;

namespace Burgerci_Proje.Entities
{
    public class Menu : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string? Photo { get; set; }
        public int Quantity { get; set; } = 1;
        public Guid HamburgerId { get; set; }
        public Guid? DrinkId { get; set; }
        public Guid? ExtraId { get; set; }
        public Hamburger Hamburger { get; set; }
        public Drink Drink { get; set; }
        public Extra Extra { get; set; }
    }
}
