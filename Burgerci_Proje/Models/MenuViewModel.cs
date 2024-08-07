﻿using BLL.DTOs;
using DAL.Enum;

namespace Burgerci_Proje.Models
{
    public class MenuViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; } = 1;
        public string? Size { get; set; }
        public IFormFile? PhotoUrl { get; set; }
        public Guid HamburgerId { get; set; }
        public Guid DrinkId { get; set; }
        public Guid ExtraId { get; set; }
        public HamburgerViewModel HamburgerViewModel { get; set; }
        public DrinkViewModel DrinkViewModel { get; set; }
        public ExtraViewModel ExtraViewModel { get; set; }

        public List<HamburgerViewModel> Hamburgers { get; set; }
        public List<ExtraViewModel> Garnitures { get; set; }
        public List<DrinkViewModel> Drinks { get; set; }
    }
}
