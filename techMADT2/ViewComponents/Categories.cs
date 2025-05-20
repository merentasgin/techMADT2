using Microsoft.AspNetCore.Mvc;
using techMADT2.Core.Entities;
using techMADT2.Service.Abstract;
namespace techMADT2.ViewComponents
{
    public class Categories:ViewComponent
    {
        private readonly IService<Category> _service;

        public Categories(IService<Category> service)
        {
            _service = service;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
             return View(await _service.GetAllAsync(c=> c.IsTopMenu && c.IsActive));
        }
    }
}
