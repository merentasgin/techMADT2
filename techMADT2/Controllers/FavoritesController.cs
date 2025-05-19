using Microsoft.AspNetCore.Mvc;
using techMADT2.Core.Entities;
using techMADT2.Data;
using techMADT2.ExtensionMethods;

namespace techMADT2.Controllers
{
    public class FavoritesController : Controller
    {

        private readonly DatabaseContext _context;

        public FavoritesController(DatabaseContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var favoriler =GetFavorites();
            return View();
        }
        private List<Product> GetFavorites()
        {

            return HttpContext.Session.GetJson<List<Product>>("GetFavorites") ?? [];
        }
        public IActionResult Add(int ProductId)
        {
            var favoriler = GetFavorites();
            var product= _context.Products.Find(ProductId);
            if (product != null && !favoriler.Any(p=>p.Id == ProductId))
            {

                favoriler.Add(product);
                HttpContext.Session.SetJson("GetFavorites", favoriler);


            }
            return RedirectToAction("Index");
        }
    }
}
