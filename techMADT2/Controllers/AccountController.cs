using Microsoft.AspNetCore.Authentication;//login
using Microsoft.AspNetCore.Authorization;//login
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims; //login
using techMADT2.Core.Entities;
using techMADT2.Models;
using techMADT2.Service.Abstract;

namespace techMADT2.Controllers
{
    public class AccountController : Controller
    {
        private readonly IService<AppUser> _service;

        public AccountController(IService<AppUser> service)
        {
            _service = service;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var userIdClaim = HttpContext.User.FindFirst("UserId")?.Value;
            AppUser user = await _service.GetAsync(x => x.Id.ToString() == userIdClaim);

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
    }
}
