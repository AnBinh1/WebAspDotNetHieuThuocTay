using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebASPDotNet.Models;

namespace WebASPDotNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly WebAspdotNetContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,WebAspdotNetContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var Products = _context.TblProducts.ToList();
			if (Products.Count == 0)
			{
				_logger.LogWarning("Không có sản phẩm nào trong cơ sở dữ liệu.");
			}
			return View(Products);
        }	
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statuscode)
        {
            if(statuscode == 404)
            {
                return View("NotFound");
            }
            else
            {
				return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
			}
            
        }
    }
}
