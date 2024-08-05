using DAL.Entities;

namespace Burgerci_Proje.Entities
{
    public class Drink : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public List<Menu> Menus { get; set; }
    }
}
