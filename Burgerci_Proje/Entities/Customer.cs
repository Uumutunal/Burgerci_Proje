namespace Burgerci_Proje.Entities
{
    public class Customer
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }

        public List<Order> Orders { get; set; }
    }
}
