using System.ComponentModel.DataAnnotations;

namespace techMADT2.Core.Entities
{
    public class AppUser : IEntity

    {
        public int Id { get; set; }
        [Display(Name="Adı")]
        public string Name { get; set; }
        [Display(Name = "Soyadı")]
        public string Surname { get; set; }

        public string Email { get; set; }
        [Display(Name = "Telefon")]
        public string? Phone { get; set; }
        [Display(Name = "Şifre")]
        public string Password { get; set; }
        [Display(Name = "Kullanıcı Adı")]
        public string? UserName { get; set; } = string.Empty;
        [Display(Name = "Aktif?")]
        public bool IsActive { get; set; }
        [Display(Name = "Admin?")]
        public bool IsAdmin { get; set; }
        [Display(Name = "Kayıt Tarihi"),ScaffoldColumn(false)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;


        [ScaffoldColumn(false)] // CRUD sayfası oluştururken bu değişkenin oluşmasını engeller
        public Guid? UpdateDate { get; set; } = Guid.NewGuid();
    }
}
