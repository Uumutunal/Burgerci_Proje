﻿using BLL.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Burgerci_Proje.Models
{
    public class HamburgerViewModel : BaseViewModel
    {

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public double Price { get; set; }
        public List<Guid>? SelectedGarnitureIds { get; set; }
        public int Quantity { get; set; } = 1;
        public string? Size { get; set; }
        public IFormFile? PhotoUrl { get; set; }
        public string? Photo {get; set;}
        public List<MenuViewModel>? MenuViewModels { get; set; }
    }
}
