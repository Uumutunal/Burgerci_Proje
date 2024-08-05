using BLL.DTOs;

namespace Burgerci_Proje.Models
{
    public class GarnitureViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public List<HamburgerGarnitureViewModel> HamburgerGarnitureViewModels { get; set; }
    }
}
