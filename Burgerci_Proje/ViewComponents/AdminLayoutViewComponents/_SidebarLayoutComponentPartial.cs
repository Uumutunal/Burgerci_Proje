using Microsoft.AspNetCore.Mvc;

namespace Burgerci_Proje.ViewComponents.AdminLayoutViewComponents
{
	public class _SidebarLayoutComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
