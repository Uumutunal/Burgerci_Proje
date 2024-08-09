namespace Burgerci_Proje.Models
{
    public class MenuItemsViewModel
    {
        public List<DrinkViewModel> Drinks { get; set; }
        public List<ExtraViewModel> Extras { get; set; }
        public List<HamburgerViewModel> Hamburgers { get; set; }
        public string SelectedCategory { get; set; }
    }
}
