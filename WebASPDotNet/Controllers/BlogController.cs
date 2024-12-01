using Microsoft.AspNetCore.Mvc;
using WebASPDotNet.Models;

namespace WebASPDotNet.Controllers
{
	public class BlogController : Controller
	{
		private readonly WebAspdotNetContext _context;
		private readonly ILogger<BlogController> _logger;

		public BlogController(ILogger<BlogController> logger, WebAspdotNetContext context)
		{
			_logger = logger;
			_context = context;
		}

		public IActionResult Index()
		{

			var Blog = _context.TblBlogs.ToList();
			if (Blog.Count == 0)
			{
				_logger.LogWarning("Không có Blog nào trong cơ sở dữ liệu.");
			}
			return View(Blog);
		}
		public IActionResult BlogDetails(string Alias)
		{
			var Blog = _context.TblBlogs.FirstOrDefault(m => m.Alias == Alias);
			if (Blog == null) return RedirectToAction("Index");
			return View(Blog);
		}
	}
}
