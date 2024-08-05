using BLL.DTOs;

namespace Burgerci_Proje.Models
{
    public class DrinkViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public List<MenuViewModel> MenuViewModels { get; set; }
    }
}
