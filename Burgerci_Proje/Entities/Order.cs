namespace Burgerci_Proje.Entities
{
    public class Order
    {
        public int CustomerId { get; set; }
        public int MenuId { get; set; }

        public List<Menu> Menus { get; set; }
        public Customer Customer { get; set; }
    }
}
