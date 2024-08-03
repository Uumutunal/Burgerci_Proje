namespace Burgerci_Proje.Entities
{
    public class Menu
    {
        public int HamburgerId { get; set; }
        public int DrinkId { get; set; }
        public int ExtraId { get; set; }
        public int OrderId { get; set; }
        public int HamburgerCount { get; set; }
        public int DrinkCount { get; set; }


        public Hambuger Hambuger { get; set; }
        public Drink Drink { get; set; }
        public Order Order { get; set; }
        public Extra Extra { get; set; }
    }
}
