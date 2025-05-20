//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using System.Threading.Tasks;
//using techMADT2.Core.Entities;
//using techMADT2.Service.Abstract;

//namespace techMADT2.Controllers
//{

//    [Authorize]
//    public class MyAddressesController : Controller
//    {
//        private readonly IService<AppUser> _serviceAppUser;
//        private readonly IService<Address> _serviceAddress;

//        public MyAddressesController(IService<AppUser> service, IService<Address> serviceAddress)
//        {
//            _serviceAppUser = service;
//            _serviceAddress = serviceAddress;
//        }
//        public async Task<IActionResult> Index()
//        {
//            var appUser = await _serviceAppUser.GetAsync(x => x.UserGuid.ToString() == HttpContext.User.FindFirst("UserGuid").Value);
//            if (appUser == null)
//            {
//                return NotFound("Kullanıcı Datası Bulunamadı! Oturumunuzu Kapatıp Lütfen Tekrar Giriş Yapın");
//            }
//            var model = await _serviceAddress.GetAllAsync(u => u.AppUserId == appUser.Id);
//            return View(model);
//        }
//    }
//}
