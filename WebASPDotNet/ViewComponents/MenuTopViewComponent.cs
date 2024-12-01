using Microsoft.AspNetCore.Mvc;
using WebASPDotNet.Models;

namespace WebASPDotNet.ViewComponents
{
	public class MenuTopViewComponent:ViewComponent
	{
		private readonly WebAspdotNetContext _context;
		public MenuTopViewComponent(WebAspdotNetContext context)
		{
			_context = context;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var items = _context.TblMenus.Where(m => m.IsActive).OrderBy(m => m.Position).ToList();
			return await Task.FromResult<IViewComponentResult>(View(items));
		}
	}
}
