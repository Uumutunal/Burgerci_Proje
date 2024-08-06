using Microsoft.AspNetCore.Mvc;

namespace Burgerci_Proje.ViewComponents.AdminLayoutViewComponents
{
	public class _MainPanelLayoutComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
