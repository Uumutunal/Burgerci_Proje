using DAL.Entities;

namespace Burgerci_Proje.Entities
{
    public class Extra : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string? Photo { get; set; }
        public int Quantity { get; set; } = 1;
        public string? Size { get; set; }
        public List<Menu> Menus { get; set; }
    }
}
