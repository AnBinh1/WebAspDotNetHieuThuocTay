using elFinder.NetCore.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.CommandLine;
using SixLabors.ImageSharp;
using WebASPDotNet.Models;

namespace WebASPDotNet.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {

        private readonly WebAspdotNetContext _context;
        private readonly IWebHostEnvironment _environment;
        public ProductController(WebAspdotNetContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _environment = webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblProducts.OrderByDescending(p => p.ProductId).Include(p => p.Category).ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Category = new SelectList(_context.TblCategories, "CategoryId", "Title");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TblProduct product)
        {
            ViewBag.Category = new SelectList(_context.TblCategories, "CategoryId", "Title", product.CategoryId);
            if (ModelState.IsValid)
            {
                product.Alias = product.Name.Replace(" ", "-");
                var Alias = await _context.TblProducts.FirstOrDefaultAsync(p => p.Alias == product.Alias);
                if (Alias != null)
                {
                    ModelState.AddModelError("", "sản phẩm đã có trong cơ sở dữ liệu");
                    return View(product);
                }
                else
                {
                    if (product.ImageUpload != null)
                    {
                        string uploadsDir = Path.Combine(_environment.WebRootPath, "images/products");
                        string imageName = Guid.NewGuid().ToString() + "_" + product.ImageUpload.FileName;
                        string filePath = Path.Combine(uploadsDir, imageName);
                        FileStream fs = new FileStream(filePath, FileMode.Create);
                        await product.ImageUpload.CopyToAsync(fs);
                        fs.Close();
                        product.Image = imageName;
                    }
                }
                _context.Add(product);
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


            return View(product);
        }

        public async Task<IActionResult> Edit(int ProductId)
        {
            TblProduct product = await _context.TblProducts.FindAsync(ProductId);
            ViewBag.Category = new SelectList(_context.TblCategories, "CategoryId", "Title", product.CategoryId);
            return View(product);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TblProduct product)
        {
            ViewBag.Category = new SelectList(_context.TblCategories, "CategoryId", "Title", product.CategoryId);
            if (ModelState.IsValid)
            {
                product.Alias = product.Name.Replace(" ", "-");
                var Alias = await _context.TblProducts.FirstOrDefaultAsync(p => p.Alias == product.Alias);
                if (Alias != null)
                {
                    ModelState.AddModelError("", "sản phẩm đã có trong cơ sở dữ liệu");
                    return View(product);
                }
                else
                {
                    if (product.ImageUpload != null)
                    {
                        string uploadsDir = Path.Combine(_environment.WebRootPath, "images/products");
                        string imageName = Guid.NewGuid().ToString() + "_" + product.ImageUpload.FileName;
                        string filePath = Path.Combine(uploadsDir, imageName);
                        FileStream fs = new FileStream(filePath, FileMode.Create);
                        await product.ImageUpload.CopyToAsync(fs);
                        fs.Close();
                        product.Image = imageName;
                    }
                }
                _context.Update(product);
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


            return View(product);
        }

        public async Task<IActionResult> Delete(int ProductId)
        {
            TblProduct product = await _context.TblProducts.FindAsync(ProductId);
            if (!string.Equals(product.Image, "noname.jpg"))
            {
                string uploadsDir = Path.Combine(_environment.WebRootPath, "images/products");
                string oldfileImage = Path.Combine(uploadsDir, product.Image);
                if (System.IO.File.Exists(oldfileImage))
                {
                    System.IO.File.Delete(oldfileImage);
                }

            }
            _context.TblProducts.Remove(product);
            await _context.SaveChangesAsync();
            TempData["success"] = "Sản phẩm đã bị xoá";
            return RedirectToAction("Index");
        }
    }
}
