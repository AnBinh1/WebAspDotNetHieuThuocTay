using Microsoft.AspNetCore.Mvc;
using WebASPDotNet.Models;

namespace WebASPDotNet.Controllers
{
	public class ContactController : Controller
	{
		private readonly WebAspdotNetContext _context;
		public ContactController(WebAspdotNetContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			return View();
		}
	}
}
