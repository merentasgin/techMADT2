using Humanizer;
using Microsoft.AspNetCore.Mvc;
using techMADT2.Core.Entities;
using techMADT2.ExtensionMethods;
using techMADT2.Models;
using techMADT2.Service.Abstract;
using techMADT2.Service.Abstract.Concrete;

namespace techMADT2.Controllers
{
    public class CartController : Controller
    {
        private readonly IService<Product> _serviceProduct;

        public CartController(IService<Product> serviceProduct)
        {
            _serviceProduct = serviceProduct;
        }
        public IActionResult Index()
        {
            var cart = GetCart();
            var model = new CartViewModel()
            {
                CartLines = cart.CartLines,
                TotalPrice = cart.TotalPrice()
            };
            return View(model);
        }
        public IActionResult Add(int ProductId, int quantity=1)
        {
            var product=_serviceProduct.Find(ProductId);
            if (product != null) 
            {
                var cart = GetCart();
                cart.AddProduct(product, quantity);
                HttpContext.Session.SetJson("Cart", cart);
                return Redirect(Request.Headers["Referer"].ToString());
            }
            return RedirectToAction("Index");
        }
        public IActionResult Update(int ProductId, int quantity = 1)
        {
            var product = _serviceProduct.Find(ProductId);
            if (product != null)
            {
                var cart = GetCart();
                cart.UpdateProduct(product, quantity);
                HttpContext.Session.SetJson("Cart", cart);

            }
            return RedirectToAction("Index");
        }
        public IActionResult Remove(int ProductId)
        {
            var product = _serviceProduct.Find(ProductId);
            if (product != null)
            {
                var cart = GetCart();
                cart.RemoveProduct(product,1);
                HttpContext.Session.SetJson("Cart", cart);
               
            }
            return RedirectToAction("Index");
        }
        private CartService GetCart()
        {
            return HttpContext.Session.GetJson<CartService>("Cart")??new CartService();
        }
    }
}
