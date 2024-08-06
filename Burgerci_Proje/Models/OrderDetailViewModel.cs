using BLL.DTOs;

namespace Burgerci_Proje.Models
{
    public class OrderDetailViewModel : BaseViewModel
    {
        public Guid OrderId { get; set; }
        public Guid MenuId { get; set; }
        public Guid HamburgerId { get; set; }
        public Guid DrinkId { get; set; }
        public Guid ExtraId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public OrderViewModel OrderViewModel { get; set; }
        public MenuViewModel MenuViewModel { get; set; }
        public HamburgerViewModel HamburgerViewModel { get; set; }
        public DrinkViewModel DrinkViewModel { get; set; }
        public ExtraViewModel ExtraViewModel { get; set; }
    }
}
