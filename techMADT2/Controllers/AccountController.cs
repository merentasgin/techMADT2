using Microsoft.AspNetCore.Authentication;//login
using Microsoft.AspNetCore.Authorization;//login
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Security.Claims; //login
using techMADT2.Core.Entities;
using techMADT2.Models;
using techMADT2.Service.Abstract;
using techMADT2.Utits;
using Microsoft.AspNetCore.Authentication.Cookies;


namespace techMADT2.Controllers
{
    public class AccountController : Controller
    {
        private readonly IService<AppUser> _service;
        private readonly IService<Order> _serviceOrder;

        public AccountController(IService<AppUser> service, IService<Order> serviceOrder)
        {
            _service = service;
            _serviceOrder = serviceOrder;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
           AppUser user=await _service.GetAsync(x=>x.UserGuid.ToString()==HttpContext.User.FindFirst("UserGuid").Value);

            if (user is null) 
            {
                return NotFound();
            }
            var model = new UserEditViewModel()
            { 
                Email = user.Email,
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
                Phone = user.Phone,
                Surname = user.Surname,
            };
            return View(model);
        }
        [HttpPost, Authorize]
        public async Task<IActionResult> IndexAsync(UserEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var userIdClaim = HttpContext.User.FindFirst("UserId")?.Value;
                    AppUser user = await _service.GetAsync(x => x.Id.ToString() == userIdClaim);


                    if (user is not null) { 
                        user.Email = model.Email;
                        user.Phone = model.Phone;
                        user.Name = model.Name;
                        user.Surname = model.Surname;
                        user.Password = model.Password;
                        _service.Update(user);
                        var sonuc=_service.SaveChanges();
                        if (sonuc > 0)
                        {
                            TempData["Message"] = @"<div class=""alert alert-success alert-dismissible fade show"" role=""alert"">
                           <strong>Bilgileriniz güncellenmiştir!</strong> 
  <button type=""button"" class=""btn-close"" data-bs-dismiss=""alert"" aria-label=""Close""></button>
</div>";
                            return RedirectToAction("Index");
                        }

                    }
                    _service.Update(user);
                    _service.SaveChanges();
                }
                catch (Exception)
                {

                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return View();
        }
        [Authorize]
        public async Task<IActionResult> MyOrders()
        {
            
            AppUser user = await _service.GetAsync(x => x.UserGuid.ToString() == HttpContext.User.FindFirst("UserGuid").Value);

            if (user is null)
            {
                await HttpContext.SignOutAsync();
                return RedirectToAction("SignIn");
            }
            var model  = _serviceOrder.GetQueryable().Where(s=>s.AppUserId==user.Id).Include(o=>o.orderLines).ThenInclude(p=>p.Product);
            return View(model);
        }
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignInAsync(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid) {

                try
                {
                    var account = await _service.GetAsync (x=>x.Email==
                    loginViewModel.Email & x.Password==loginViewModel.Password & x.IsActive);
                    if (account == null)
                    {

                        ModelState.AddModelError("", "Giriş Başarısız!");
                    }
                    else {
                      
                        var claims = new List<Claim>() 
                        {
                         new(ClaimTypes.Name, account.Name),
                         new(ClaimTypes.Role, account.IsAdmin ? "Admin" : "Customer"),
                         new(ClaimTypes.Email, account.Email),
                         new("UserId", account.Id.ToString()),
                         new("UserGuid",account.UserGuid.ToString()),
                         
                        };
                        var userIdentity = new ClaimsIdentity(claims, "Login");
                        ClaimsPrincipal userPrincipal = new ClaimsPrincipal(userIdentity);
                        await HttpContext.SignInAsync(userPrincipal);
                        return Redirect(string.IsNullOrEmpty(loginViewModel.ReturnUrl)? "/" : loginViewModel.ReturnUrl );
                    }
                }
                catch (Exception hata)
                {

                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            
            
            }
            return View(loginViewModel);
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]

      
      

        public async Task<IActionResult> SignUpAsync(AppUser appUser)

        
        {
            if (ModelState.IsValid)
            {
                appUser.IsAdmin = false;
                appUser.IsActive = true;
                await _service.AddAsync(appUser);
                await _service.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(appUser); 
        }
        public async Task<IActionResult> SignOutAsync()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("SignIn");
        }
        public IActionResult PasswordRenew()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> PasswordRenewAsync(string Email)
        {
            if (string.IsNullOrWhiteSpace(Email))
            {
                ModelState.AddModelError("", "Email Boş Geçilmez");
                return View();
            }
            AppUser user = await _service.GetAsync(x => x.Email==Email);

            if (user is null)
            {
                ModelState.AddModelError("", "Geçersiz Mail");
                return View();
            }
            string mesaj = $"Şifrenizi Yenilemek İçin Lütfen <a href='https://localhost:7048/Account/PasswordChange?user={user.UserGuid.ToString()}'>Buraya Tıklayınız</a>";
            var sonuc=await MailHelper.SendMailAsync(Email,"Şifremi Yenile",mesaj);
            if (sonuc)
            {
                TempData["Message"] = @"<div class=""alert alert-success alert-dismissible fade show"" role=""alert"">
                           <strong>Şifre Sıfırlama Bağlantınız Mail Adresinize Gönderilmiştir!!</strong> 
                        <button type=""button"" class=""btn-close"" data-bs-dismiss=""alert"" aria-label=""Close""></button>
                        </div>";
            }
            else {
                TempData["Message"] = @"<div class=""alert alert-danger alert-dismissible fade show"" role=""alert"">
                           <strong>Şifre Sıfırlama Bağlantınız Mail Adresinize Gönderilemedi!</strong> 
                       <button type=""button"" class=""btn-close"" data-bs-dismiss=""alert"" aria-label=""Close""></button>
                     </div>";
            }
            return View();
        }
        public async Task<IActionResult> PasswordChangeAsync(string user)
        {
            if(user is null)
            {
                return BadRequest("Geçersiz Başvuru");
            }
            AppUser appUser = await _service.GetAsync(x => x.UserGuid.ToString() == user);

            if (appUser is null)
            {
                return NotFound("Geçersiz Deger");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> PasswordChange(string user,string Password)
        {
            if (user is null)
            {
                return BadRequest("Geçersiz Başvuru");
            }
            AppUser appUser = await _service.GetAsync(x => x.UserGuid.ToString() == user);

            if (appUser is null)
            {
                ModelState.AddModelError("", "Geçersiz Değer");
                return View();
            }
            appUser.Password = Password;    
            var sonuc =await _service.SaveChangesAsync();
            if (sonuc>0)
            {
                TempData["Message"] = @"<div class=""alert alert-success alert-dismissible fade show"" role=""alert"">
                           <strong>Şifreniz Güncellenmiştir Oturum Açabilirsiniz</strong> 
                        <button type=""button"" class=""btn-close"" data-bs-dismiss=""alert"" aria-label=""Close""></button>
                        </div>";

            }
            else
            {
                ModelState.AddModelError("", "Güncelleme Başarısız");
            }
            return View();
        }
    }
}
