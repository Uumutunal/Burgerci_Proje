using Microsoft.AspNetCore.Mvc;

namespace Burgerci_Proje.ViewComponents.AdminLayoutViewComponents
{
	public class _CustomTemplateLayoutComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
