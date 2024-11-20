using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebASPDotNet.Models;

namespace WebASPDotNet.ViewComponents
{
	public class CategoriesViewComponent:ViewComponent
	{
		private readonly WebAspdotNetContext _context;
		public CategoriesViewComponent(WebAspdotNetContext context)
		{
			_context = context;
		}
		public async Task<IViewComponentResult> InvokeAsync() => View(await _context.TblCategories.ToListAsync());
		
	}
}
