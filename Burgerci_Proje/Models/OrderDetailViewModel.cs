using BLL.DTOs;

namespace Burgerci_Proje.Models
{
    public class OrderDetailViewModel : BaseViewModel
    {
        public Guid OrderId { get; set; }
        public Guid MenuId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public OrderViewModel OrderViewModel { get; set; }
        public MenuViewModel MenuViewModel { get; set; }
    }
}
