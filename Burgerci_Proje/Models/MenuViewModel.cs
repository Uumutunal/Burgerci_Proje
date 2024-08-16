using BLL.DTOs;
using DAL.Enum;
using System.ComponentModel.DataAnnotations;

namespace Burgerci_Proje.Models
{
    public class MenuViewModel : BaseViewModel
    {

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public double Price { get; set; }

        public int Quantity { get; set; } = 1;

        public string? Size { get; set; }

        public IFormFile? PhotoUrl { get; set; }

        public string? Photo { get; set; }

        public Guid HamburgerId { get; set; }

        public Guid DrinkId { get; set; }

        public Guid ExtraId { get; set; }

        public HamburgerViewModel? HamburgerViewModel { get; set; }
        public DrinkViewModel? DrinkViewModel { get; set; }
        public ExtraViewModel? ExtraViewModel { get; set; }

    }
}
