using BLL.DTOs;

namespace Burgerci_Proje.Models
{
    public class MenuViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; } = 1;
        public IFormFile? PhotoUrl { get; set; }
        public Guid HamburgerId { get; set; }
        public Guid DrinkId { get; set; }
        public Guid ExtraId { get; set; }
        public HamburgerViewModel HamburgerViewModel { get; set; }
        public DrinkViewModel DrinkViewModel { get; set; }
        public ExtraViewModel ExtraViewModel { get; set; }
    }
}
