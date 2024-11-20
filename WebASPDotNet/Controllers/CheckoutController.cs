using Microsoft.AspNetCore.Mvc;

namespace WebASPDotNet.Controllers
{
	public class CheckoutController:Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
