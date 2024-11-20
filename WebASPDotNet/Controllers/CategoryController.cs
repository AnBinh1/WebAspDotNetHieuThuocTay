using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebASPDotNet.Models;

namespace WebASPDotNet.Controllers
{
	public class CategoryController:Controller
	{
		private readonly WebAspdotNetContext _context;
		public CategoryController(WebAspdotNetContext context)
		{
			_context = context;
		}
		public async Task<IActionResult> Index(string Alias)
		{
			TblCategory category = _context.TblCategories.Where(m => m.Alias == Alias).FirstOrDefault();
			if (category == null) return RedirectToAction("Index");
			var ProductByCategory = _context.TblProducts.Where(m => m.CategoryId == category.CategoryId);
			return View(await ProductByCategory.OrderByDescending(m => m.ProductId).ToListAsync());
		}
	}
}
