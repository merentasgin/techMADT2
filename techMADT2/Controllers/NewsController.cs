using Microsoft.AspNetCore.Mvc;
using techMADT2.Core.Entities;
using techMADT2.Service.Abstract;

namespace techMADT2.Controllers
{
    public class NewsController : Controller
    {
        private readonly IService<News> _service;

        public NewsController(IService<News> service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _service.GetAsync(m => m.Id == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }
    }
}
