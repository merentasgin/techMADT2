using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using techMADT2.Data;

namespace techMADT2.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "AdminPolicy")]
    public class MainController : Controller
    {
        private readonly DatabaseContext _context;

        public MainController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Products=_context.Products;
            return View();
        }
    }
}
