using Microsoft.AspNetCore.Mvc;

namespace Burgerci_Proje.ViewComponents.AdminLayoutViewComponents
{
	public class _HeadLayoutComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
