using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebASPDotNet.Models;

namespace WebASPDotNet.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuController : Controller
    {
		public readonly WebAspdotNetContext _context;
		public MenuController(WebAspdotNetContext context)
		{
			_context = context;
		}
		public async Task<IActionResult> Index()
        {
            return View(await _context.TblMenus.OrderByDescending(p => p.MenuId).ToListAsync());
        }
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(TblMenu menu)
		{
			if (ModelState.IsValid)
			{
				menu.Alias = menu.Title.Replace(" ", "-");
				var Alias = await _context.TblMenus.FirstOrDefaultAsync(p => p.Alias == menu.Alias);
				if (Alias != null)
				{
					ModelState.AddModelError("", "Danh mục đã có trong cơ sở dữ liệu");
					return View(menu);
				}
				_context.Add(menu);
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


			return View(menu);
		}
		public async Task<IActionResult> Edit(int MenuId)
		{
			TblMenu menu = await _context.TblMenus.FindAsync(MenuId);
			return View(menu);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(TblMenu menu)
		{
			if (ModelState.IsValid)
			{
				menu.Alias = menu.Title.Replace(" ", "-");
				var Alias = await _context.TblMenus.FirstOrDefaultAsync(p => p.Alias == menu.Alias);
				if (Alias != null)
				{
					ModelState.AddModelError("", "Tên Menu đã có trong cơ sở dữ liệu");
					return View(menu);
				}
				_context.Update(menu);
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


			return View(menu);
		}
		public async Task<IActionResult> Delete(int MenuId)
		{
			TblMenu menu = await _context.TblMenus.FindAsync(MenuId);

			_context.TblMenus.Remove(menu);
			await _context.SaveChangesAsync();
			TempData["success"] = "Sản phẩm đã bị xoá";
			return RedirectToAction("Index");
		}
	}
}
