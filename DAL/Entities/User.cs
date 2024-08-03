using DAL.Entities;

namespace Burgerci_Proje.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public List<Order> Orders { get; set; }
    }
}
