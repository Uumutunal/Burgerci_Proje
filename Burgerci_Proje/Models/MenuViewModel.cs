using BLL.DTOs;

namespace Burgerci_Proje.Models
{
    public class MenuViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public Guid HamburgerId { get; set; }
        public Guid DrinkId { get; set; }
        public Guid SnackId { get; set; }
        public HamburgerViewModel HamburgerViewModel { get; set; }
        public DrinkViewModel DrinkViewModel { get; set; }
        public ExtraViewModel ExtraViewModel { get; set; }

        public List<HamburgerViewModel> Hamburgers { get; set; }
        public List<ExtraViewModel> Garnitures { get; set; }
        public List<DrinkViewModel> Drinks { get; set; }
    }
}
