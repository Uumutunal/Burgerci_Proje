﻿using BLL.DTOs;

namespace Burgerci_Proje.Models
{
    public class HamburgerGarnitureViewModel : BaseViewModel
    {
        public Guid HamburgerId { get; set; }
        public Guid GarnitureId { get; set; }
        public HamburgerViewModel HamburgerViewModel { get; set; }
        public GarnitureViewModel GarnitureViewModel { get; set; }
    }
}
