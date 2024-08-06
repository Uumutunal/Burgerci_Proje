using BLL.DTOs;

namespace Burgerci_Proje.Models
{
    public class HamburgerViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string? ImageUrl { get; set; }
        public IFormFile? PhotoUrl { get; set; }
        public List<Guid> SelectedGarnitureIds { get; set; }
        public List<MenuViewModel>? MenuViewModels { get; set; }
    }
}
