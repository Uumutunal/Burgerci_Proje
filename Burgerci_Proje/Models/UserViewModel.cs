using BLL.DTOs;

namespace Burgerci_Proje.Models
{
    public class UserViewModel : BaseViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public List<OrderViewModel> OrderViewModels { get; set; }
    }
}
