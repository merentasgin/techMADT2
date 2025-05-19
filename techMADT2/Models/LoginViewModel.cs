using System.ComponentModel.DataAnnotations;

namespace techMADT2.Models
{
    public class LoginViewModel
    {
        [DataType(DataType.EmailAddress),Required (ErrorMessage ="Email Alanının Doldurulması Zorunludur!")]
        public string Email { get; set; }
        [Display(Name = "Şifre")]
        [DataType(DataType.Password), Required(ErrorMessage = "Şifre Alanının Doldurulması Zorunludur!")]
        public string Password { get; set; }
        public string? ReturnUrl { get; set; }
        public bool RememberMe { get; set; }

    }
}
