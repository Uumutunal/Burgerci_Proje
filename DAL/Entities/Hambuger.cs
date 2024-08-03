using DAL.Entities;

namespace Burgerci_Proje.Entities
{
    public class Hambuger : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public List<Menu> Menus { get; set; }
    }
}
