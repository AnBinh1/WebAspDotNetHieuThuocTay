using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebASPDotNet.Models;
using WebASPDotNet.Models.ViewModels;
using WebASPDotNet.Repository;

namespace WebASPDotNet.Controllers
{
	public class CartController : Controller
	{
		//moi 
		private readonly WebAspdotNetContext _context;
		public CartController(WebAspdotNetContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			List<TblCart> CartItems = HttpContext.Session.GetJson<List<TblCart>>("Cart") ?? new List<TblCart>();
			CartItemViewModel CartVM = new()
			{
				CartItems = CartItems,
				GrandTotal = CartItems.Sum(x => x.Quantity * x.Price)
			};
			return View(CartVM);
		}
		public async Task<IActionResult> Add(int Id)
		{
			TblProduct product = await _context.TblProducts.FindAsync(Id);

			if (product == null)
			{
				return RedirectToAction("Index", "Products");
			}

			List<TblCart> CartItems = HttpContext.Session.GetJson<List<TblCart>>("Cart") ?? new List<TblCart>();

			// Kiểm tra và thêm sản phẩm
			TblCart cartItem = CartItems.FirstOrDefault(x => x.CartId == Id);

			if (cartItem == null)
			{
				CartItems.Add(new TblCart
				{
					CartId = product.ProductId,
					Name = product.Name,
					Image = product.Image,
					Price = product.Price,
					Quantity = 1
				});
			}
			else
			{
				cartItem.Quantity += 1;
			}

			// Lưu lại giỏ hàng vào Session
			HttpContext.Session.SetJson("Cart", CartItems);

			return RedirectToAction("Index");
		}
		public async Task<IActionResult> Decrease(int Id)
		{
			List<TblCart> CartItems = HttpContext.Session.GetJson<List<TblCart>>("Cart");
			TblCart cartItems = CartItems.Where(c => c.CartId == Id).FirstOrDefault();
			if (cartItems.Quantity >= 1)
			{
				--cartItems.Quantity;
			}
			else
			{
				CartItems.RemoveAll(x => x.CartId == Id);
			}
			if (CartItems.Count == 0)
			{
				HttpContext.Session.Remove("Cart");
			}
			else
			{
				HttpContext.Session.SetJson("Cart", CartItems);
			}
			return RedirectToAction("Index");
		}
		public async Task<IActionResult> Increase(int Id)
		{
			List<TblCart> CartItems = HttpContext.Session.GetJson<List<TblCart>>("Cart");
			TblCart cartItems = CartItems.Where(c => c.CartId == Id).FirstOrDefault();
			if (cartItems.Quantity >= 1)
			{
				++cartItems.Quantity;
			}
			else
			{
				CartItems.RemoveAll(x => x.CartId == Id);
			}
			if (CartItems.Count == 0)
			{
				HttpContext.Session.Remove("Cart");
			}
			else
			{
				HttpContext.Session.SetJson("Cart", CartItems);
			}
			return RedirectToAction("Index");
		}
		public async Task<IActionResult> Remove(int Id)
		{
			List<TblCart> CartItems = HttpContext.Session.GetJson<List<TblCart>>("Cart");
			CartItems.RemoveAll(p => p.CartId == Id);
			if (CartItems.Count == 0)
			{
				HttpContext.Session.Remove("Cart");
			}
			else
			{
				HttpContext.Session.SetJson("Cart", CartItems);
			}
			return RedirectToAction("Index");
		}
		
	}

    }