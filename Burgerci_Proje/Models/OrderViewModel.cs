using BLL.DTOs;

namespace Burgerci_Proje.Models
{
    public class OrderViewModel : BaseViewModel
    {
        public Guid UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalPrice { get; set; }
        public string Status { get; set; }
        public UserViewModel UserViewModel { get; set; }
        public List<OrderDetailViewModel> OrderDetailViewModels { get; set; }
    }
}
