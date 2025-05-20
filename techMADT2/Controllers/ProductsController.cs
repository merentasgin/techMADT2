using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using techMADT2.Core.Entities;
using techMADT2.Data;
using techMADT2.Models;

namespace techMADT2.Controllers
{
    public class ProductsController : Controller
    {
        private readonly DatabaseContext _context;

       
        public ProductsController(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string q = "", int? categoryId = null)
        {
            IQueryable<Product> products = _context.Products
                .Where(p => p.IsActive)
                .Include(p => p.Brand)
                .Include(p => p.Category);

            if (!string.IsNullOrEmpty(q))
            {
                products = products.Where(p => p.Name.Contains(q) || p.Description.Contains(q));
            }

            if (categoryId != null)
            {
                products = products.Where(p => p.CategoryId == categoryId);
            }

            return View(await products.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            var model = new ProductDetailViewModel()
            {
                Product= product,
                RelatedProducts= _context.Products.Where(p => p.IsActive && p.CategoryId==product.CategoryId && p.Id != product.Id)
            };
            return View(model);




        }
    }
}
