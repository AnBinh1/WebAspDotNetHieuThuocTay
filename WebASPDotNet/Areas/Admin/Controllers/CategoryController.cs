using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using WebASPDotNet.Models;

namespace WebASPDotNet.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CategoryController:Controller
	{
		
		public readonly WebAspdotNetContext _context;
		public CategoryController(WebAspdotNetContext context)
		{
			_context = context;
		}
		public async Task<IActionResult> Index()
		{
			return View(await _context.TblCategories.OrderByDescending(p => p.CategoryId).ToListAsync());
		}
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(TblCategory category)
		{
			if (ModelState.IsValid)
			{
				category.Alias = category.Title.Replace(" ", "-");
				var Alias = await _context.TblProducts.FirstOrDefaultAsync(p => p.Alias == category.Alias);
				if (Alias != null)
				{
					ModelState.AddModelError("", "Danh mục đã có trong cơ sở dữ liệu");
					return View(category);
				}
				_context.Add(category);
				await _context.SaveChangesAsync();
				TempData["success"] = "bạn đã thêm thành công";
				return RedirectToAction("Index");
			}
			else
			{
				TempData["error"] = "có một vài thứ đang bị lỗi";
				List<string> errors = new List<string>();
				foreach (var value in ModelState.Values)
				{
					foreach (var error in value.Errors)
					{
						errors.Add(error.ErrorMessage);
					}
				}
				string ErrorMessage = string.Join("\n", errors);
				return BadRequest(ErrorMessage);
			}


			return View(category);
		}
		public async Task<IActionResult> Edit(int CategoryId)
		{
			TblCategory category = await _context.TblCategories.FindAsync(CategoryId);
			return View(category);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(TblCategory category)
		{
			if (ModelState.IsValid)
			{
				category.Alias = category.Title.Replace(" ", "-");
				var Alias = await _context.TblProducts.FirstOrDefaultAsync(p => p.Alias == category.Alias);
				if (Alias != null)
				{
					ModelState.AddModelError("", "Danh mục đã có trong cơ sở dữ liệu");
					return View(category);
				}
				_context.Update(category);
				await _context.SaveChangesAsync();
				TempData["success"] = "bạn đã sửa thành công";
				return RedirectToAction("Index");
			}
			else
			{
				TempData["error"] = "có một vài thứ đang bị lỗi";
				List<string> errors = new List<string>();
				foreach (var value in ModelState.Values)
				{
					foreach (var error in value.Errors)
					{
						errors.Add(error.ErrorMessage);
					}
				}
				string ErrorMessage = string.Join("\n", errors);
				return BadRequest(ErrorMessage);
			}


			return View(category);
		}
		public async Task<IActionResult> Delete(int CategoryId)
        {
			TblCategory category = await _context.TblCategories.FindAsync(CategoryId);

			_context.TblCategories.Remove(category);
            await _context.SaveChangesAsync();
            TempData["success"] = "Sản phẩm đã bị xoá";
            return RedirectToAction("Index");
        }
    }
}
