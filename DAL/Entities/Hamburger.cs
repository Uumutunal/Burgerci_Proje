using DAL.Entities;

namespace Burgerci_Proje.Entities
{
    public class Hamburger : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string? Photo { get; set; }
        public List<Menu> Menus { get; set; }
        public List<HamburgerGarniture> HamburgerGarnitures { get; set; }

    }
}
