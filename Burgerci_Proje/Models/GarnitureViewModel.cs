using BLL.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Burgerci_Proje.Models
{
    public class GarnitureViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public double Price { get; set; }

        public List<HamburgerGarnitureViewModel>? HamburgerGarnitureViewModels { get; set; }
    }
}
