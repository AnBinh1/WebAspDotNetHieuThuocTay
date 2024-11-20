using Microsoft.AspNetCore.Mvc;

namespace WebASPDotNet.Controllers
{
	public class LoginController:Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
