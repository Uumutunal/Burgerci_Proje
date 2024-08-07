using BLL.DTOs;

namespace Burgerci_Proje.Models
{
    public class HamburgerViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; } = 1;
        public IFormFile PhotoUrl { get; set; }
        public string? Photo { get; set; }
        public List<MenuViewModel> MenuViewModels { get; set; }
    }
}
