using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly WebshopdbContext _context;
        public ProductController(WebshopdbContext context)
        {
            _context = context;
        }
        // GET: ProductController
        public ActionResult Index()
        {
            // Load new products
            ViewBag.NewProducts = new List<string>();

            // Load featured products
            // LINQ 1: https://learn.microsoft.com/en-us/dotnet/csharp/linq/get-started/query-expression-basics
            List<Product> featureProducts = _context.Products.Where(pr => pr.IsFeatured == true).Take(3).ToList();
            ViewBag.FeaturedProducts = featureProducts;

            // Load promotion products            
            // LINQ 2: https://learn.microsoft.com/en-us/dotnet/csharp/linq/get-started/query-expression-basics
            IEnumerable<Product> promoProducts = from p in _context.Products
                                                 where p.IsPromotion == true
                                                 select p;
            
            ViewBag.PromotionProducts = promoProducts.ToList();

            // Load all products
            ViewBag.AllProducts = _context.Products.ToList();

            // Load categories
            ViewBag.ProductCategories = _context.ProductCategories.ToList();

            return View("Product");
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            ViewData["ProductId"] = id;
            // Load categories
            ViewBag.ProductCategories = _context.ProductCategories.ToList<ProductCategory>();

            //load product
            Product product = _context.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductId == id);

            return View("ProductDetail", product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
