using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using techMADT2.Core.Entities;
using techMADT2.Models;
using techMADT2.Service.Abstract;
using techMADT2.Utits;

namespace techMADT2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IService<Product> _serviceProduct;
        private readonly IService<Slider> _serviceSlider;
        private readonly IService<News> _serviceNews;
        private readonly IService<Contact> _serviceContact;
        private readonly IService<Category> _serviceCategory;

        public HomeController(IService<Product> serviceProduct, IService<Slider> serviceSlider, IService<News> serviceNews, IService<Contact> serviceContact, IService<Category> serviceCategory)
        {
            _serviceProduct = serviceProduct;
            _serviceSlider = serviceSlider;
            _serviceNews = serviceNews;
            _serviceContact = serviceContact;
            _serviceCategory = serviceCategory;
        }

        public async Task<IActionResult> Index()
        {
            var model = new HomePageViewModel()
            {
                Sliders= await _serviceSlider.GetAllAsync(),
                News = await _serviceNews.GetAllAsync(news=>news.IsActive),
                Products = await _serviceProduct.GetAllAsync(p=>p.IsActive&&p.IsHome),
                 Categories = await _serviceCategory.GetQueryable().Include(c => c.Products).ToListAsync()
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [Route("AccessDenied")]
        public IActionResult AccessDenied()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ContactUsAsync(Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _serviceContact.AddAsync(contact);
                    var sonuc= _serviceContact.SaveChanges();
                    if (sonuc>0)
                    {
                        TempData["Message"] = @"<div class=""alert alert-success alert-dismissible fade show"" role=""alert"">
                           <strong>Mesajýnýz Gönderilmiþtir!</strong> 
  <button type=""button"" class=""btn-close"" data-bs-dismiss=""alert"" aria-label=""Close""></button>
</div>";
                       //await MailHelper.SendMailAsync(contact);
                        return RedirectToAction("ContactUs");
                    }
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Hata Oluþtu!");
                }
            }
            return View(contact);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
