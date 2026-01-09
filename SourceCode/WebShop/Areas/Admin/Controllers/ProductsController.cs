using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using WebShop.Models;
using static System.Net.Mime.MediaTypeNames;

namespace WebShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly WebshopdbContext _context;
        private readonly IWebHostEnvironment _appEnvironment;

        public ProductsController(WebshopdbContext context)
        {
            _context = context;
        }

        // GET: Admin/Products
        public async Task<IActionResult> Index()
        {
            var webshopdbContext = _context.Products.Include(p => p.Category);
            return View(await webshopdbContext.ToListAsync());
        }

        // GET: Admin/Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Admin/Products/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.ProductCategories, "ProductCategoryId", "ProductCategoryId");
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductNumber,Name,ShortDesc,Description,Unit,UnitPrice,Oldprice,CategoryId,IsPromotion,IsFeatured,SmallImageFileName,BigImage,IsInstock,CreatedBy,CreatedOn")] Product product)
        {
            ProductCategory category = _context.ProductCategories.Find(product.CategoryId);
            product.Category = category;
            product.CreatedOn = DateTime.Now;
            product.CreatedBy = 1; // Placeholder for the user ID, replace with actual user ID in a real application

            ModelState.Remove("Category");

            if (ModelState.IsValid)
            {
                //Luu file             

                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                // Use a breakpoint here to inspect the 'errors' variable
            }

            ViewData["CategoryId"] = new SelectList(_context.ProductCategories, "ProductCategoryId", "ProductCategoryId", product.CategoryId);
            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.ProductCategories, "ProductCategoryId", "ProductCategoryId", product.CategoryId);
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductNumber,Name,ShortDesc,Description,Unit,UnitPrice,Oldprice,CategoryId,IsPromotion,IsFeatured,SmallImage,BigImage,IsInstock,CreatedBy,CreatedOn")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.ProductCategories, "ProductCategoryId", "ProductCategoryId", product.CategoryId);
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }

        private string MakeFileNameUnique(string fileName)
        {
            string newFileName = string.Empty;

            int lastIndex = fileName.LastIndexOf('.');
            var name = fileName.Substring(0, lastIndex);
            var ext = fileName.Substring(lastIndex + 1);

            //var fileName2 = name + "_" + Guid.NewGuid().ToString().Replace("-", string.Empty) + "." + ext;
            newFileName = name + "_" + string.Format("{0}{1}{2}{3}", DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second) + "." + ext;

            return newFileName;
        }
    }
}
