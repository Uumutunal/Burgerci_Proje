using DAL.Entities;

namespace Burgerci_Proje.Entities
{
    public class Hamburger : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public List<Menu> Menus { get; set; }
    }
}
