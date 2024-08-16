using BLL.DTOs;

namespace Burgerci_Proje.Models
{
    public class UserViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public IFormFile? PhotoUrl { get; set; }
        public string? Photo { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public bool IsAdmin { get; set; } = false;
        public List<OrderViewModel>? OrderViewModels { get; set; }
    }
}
