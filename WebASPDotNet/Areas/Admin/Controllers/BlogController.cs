using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebASPDotNet.Models;

namespace WebASPDotNet.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class BlogController : Controller
	{
		private readonly WebAspdotNetContext _context;
		private readonly IWebHostEnvironment _environment;
		public BlogController(WebAspdotNetContext context, IWebHostEnvironment webHostEnvironment)
		{
			_context = context;
			_environment = webHostEnvironment;
		}
		public async Task<IActionResult> Index()
		{
			return View(await _context.TblBlogs.OrderByDescending(p => p.BlogId).Include(p => p.Category).ToListAsync());
		}
		[HttpGet]
		public IActionResult Create()
		{
			ViewBag.Category = new SelectList(_context.TblCategories, "CategoryId", "Title");
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(TblBlog blog)
		{
			ViewBag.Category = new SelectList(_context.TblCategories, "CategoryId", "Title",blog.CategoryId);
			if (ModelState.IsValid)
			{
				blog.Alias = blog.Title.Replace(" ", "-");
				var Alias = await _context.TblBlogs.FirstOrDefaultAsync(p => p.Alias == blog.Alias);
				if (Alias != null)
				{
					ModelState.AddModelError("", "sản phẩm đã có trong cơ sở dữ liệu");
					return View(blog);
				}
				else
				{
					if (blog.ImageUpload != null)
					{
						string uploadsDir = Path.Combine(_environment.WebRootPath, "images/blogs");
						string imageName = Guid.NewGuid().ToString() + "_" + blog.ImageUpload.FileName;
						string filePath = Path.Combine(uploadsDir, imageName);
						FileStream fs = new FileStream(filePath, FileMode.Create);
						await blog.ImageUpload.CopyToAsync(fs);
						fs.Close();
						blog.Image = imageName;
					}
				}
				_context.Add(blog);
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


			return View(blog);
		}
		public async Task<IActionResult> Edit(int BlogId)
		{
			TblBlog blog = await _context.TblBlogs.FindAsync(BlogId);
			ViewBag.Category = new SelectList(_context.TblCategories, "CategoryId", "Title", blog.CategoryId);
			return View(blog);

		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(TblBlog blog)
		{
			ViewBag.Category = new SelectList(_context.TblCategories, "CategoryId", "Title", blog.CategoryId);
			if (ModelState.IsValid)
			{
				blog.Alias = blog.Title.Replace(" ", "-");
				var Alias = await _context.TblBlogs.FirstOrDefaultAsync(p => p.Alias == blog.Alias);
				if (Alias != null)
				{
					ModelState.AddModelError("", "Tin tức đã có trong cơ sở dữ liệu");
					return View(blog);
				}
				else
				{
					if (blog.ImageUpload != null)
					{
						string uploadsDir = Path.Combine(_environment.WebRootPath, "images/blogs");
						string imageName = Guid.NewGuid().ToString() + "_" + blog.ImageUpload.FileName;
						string filePath = Path.Combine(uploadsDir, imageName);
						FileStream fs = new FileStream(filePath, FileMode.Create);
						await blog.ImageUpload.CopyToAsync(fs);
						fs.Close();
						blog.Image = imageName;
					}
				}
				_context.Update(blog);
				await _context.SaveChangesAsync();
				TempData["success"] = "bạn đã Sửa thành công";
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


			return View(blog);
		}

		public async Task<IActionResult> Delete(int BlogId)
		{
			TblBlog blog = await _context.TblBlogs.FindAsync(BlogId);
			if (!string.Equals(blog.Image, "noname.jpg"))
			{
				string uploadsDir = Path.Combine(_environment.WebRootPath, "images/blogs");
				string oldfileImage = Path.Combine(uploadsDir, blog.Image);
				if (System.IO.File.Exists(oldfileImage))
				{
					System.IO.File.Delete(oldfileImage);
				}

			}
			_context.TblBlogs.Remove(blog);
			await _context.SaveChangesAsync();
			TempData["success"] = "Sản phẩm đã bị xoá";
			return RedirectToAction("Index");
		}

	}
}
