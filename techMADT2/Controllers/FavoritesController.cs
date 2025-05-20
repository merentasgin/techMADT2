﻿using Microsoft.AspNetCore.Mvc;
using techMADT2.Core.Entities;
using techMADT2.ExtensionMethods;
using techMADT2.Service.Abstract;

namespace techMADT2.Controllers
{
    public class FavoritesController : Controller
    {

        private readonly IService<Product> _service;

        public FavoritesController(IService<Product> service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            var favoriler =GetFavorites();
            return View(favoriler);
        }
        private List<Product> GetFavorites()
        {

            return HttpContext.Session.GetJson<List<Product>>("GetFavorites") ?? [];
        }
        public IActionResult Add(int ProductId)
        {
            var favoriler = GetFavorites();
            var product= _service.Find(ProductId);
            if (product != null && !favoriler.Any(p=>p.Id == ProductId))
            {

                favoriler.Add(product);
                HttpContext.Session.SetJson("GetFavorites", favoriler);


            }
            return RedirectToAction("Index");
        }
        public IActionResult Remove(int ProductId)
        {
            var favoriler = GetFavorites();
            var product = _service.Find(ProductId);
            if (product != null && favoriler.Any(p => p.Id == ProductId))
            {

                favoriler.RemoveAll(i=>i.Id==product.Id);
                HttpContext.Session.SetJson("GetFavorites", favoriler);


            }
            return RedirectToAction("Index");
        }
    }
}
