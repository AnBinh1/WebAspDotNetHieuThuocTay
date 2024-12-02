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
		[HttpPost]
		public IActionResult Create(string name, string phone, string email, string message)
		{
			try
			{
				TblContact contact = new TblContact();
				contact.Name = name;
				contact.Phone = phone;
				contact.Email = email;
				contact.Message = message;
				_context.Add(contact);
				_context.SaveChangesAsync();
				TempData["success"] = "Gửi Liên hệ thành công";
				return RedirectToAction("Index");
			}
			catch
			{
				TempData["error"] = "Gửi liên hệ không thành công";
				return RedirectToAction("Index");
			}
		}
	}
}
