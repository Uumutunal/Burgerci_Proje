using DAL.Entities;

namespace Burgerci_Proje.Entities
{
    public class Drink : BaseEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string? Photo { get; set; }
        public List<Menu> Menus { get; set; }
    }
}
