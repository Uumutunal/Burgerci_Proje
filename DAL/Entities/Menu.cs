using DAL.Entities;
using System;

namespace Burgerci_Proje.Entities
{
    public class Menu : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public Guid HamburgerId { get; set; }
        public Guid DrinkId { get; set; }
        public Guid SnackId { get; set; }
        public Hambuger Hamburger { get; set; }
        public Drink Drink { get; set; }
        public Extra Extra { get; set; }
    }
}
