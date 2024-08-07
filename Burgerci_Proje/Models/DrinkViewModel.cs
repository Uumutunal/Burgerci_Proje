using BLL.DTOs;

namespace Burgerci_Proje.Models
{
    public class DrinkViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; } = 1;
        public IFormFile PhotoUrl { get; set; }
        public string? Photo { get; set; }
        public List<MenuViewModel> MenuViewModels { get; set; }
    }
}
