using Microsoft.AspNetCore.Mvc;
using WebASPDotNet.Models;

namespace WebASPDotNet.Controllers
{
	public class ProductController:Controller
	{
		private readonly WebAspdotNetContext _context;
		public ProductController(WebAspdotNetContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult ProductDetails(string Alias)
		{
			TblProduct Product = _context.TblProducts.Where(m => m.Alias == Alias).FirstOrDefault();
			if (Product == null) return RedirectToAction("Index");
			var ProductByAlias = _context.TblProducts.Where( m => m.Alias == Alias ).FirstOrDefault();
			return View(ProductByAlias);
		}
	}
}
