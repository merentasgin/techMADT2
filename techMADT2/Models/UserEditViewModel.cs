using System.ComponentModel.DataAnnotations;

namespace techMADT2.Models
{
    public class UserEditViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Adı"),Required(ErrorMessage = "Ad Alanının Doldurulması Zorunludur!")]
        public string Name { get; set; }
        [Display(Name = "Soyadı"), Required(ErrorMessage = "Soyad Alanı Doldurulması Zorunludur!")]
        public string Surname { get; set; }

        public string Email { get; set; }
        [Display(Name = "Telefon"), Required(ErrorMessage = "Telefon Alanının Doldurulması Zorunludur!")]
        public string? Phone { get; set; }
        [Display(Name = "Şifre"), Required(ErrorMessage = "Şifre Alanının Doldurulması Zorunludur!")]
        public string Password { get; set; }
    }
}
