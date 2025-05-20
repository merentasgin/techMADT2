using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace techMADT2.Core.Entities
{
    public class Address:IEntity
    {
        public int Id { get; set; }
        [Display(Name="Adres Başlığı"), StringLength(50),Required(ErrorMessage = "{0} Alanı Zorunludur")]
        public string Title { get; set; }
        [Display(Name = "Şehir"), StringLength(50), Required(ErrorMessage = "{0} Alanı Zorunludur")]
        public string City {  get; set; }
        [Display(Name = "İlçe"), StringLength(50), Required(ErrorMessage = "{0} Alanı Zorunludur")]
        public string District { get; set; }
        [Display(Name = "Açık Adres"),DataType(DataType.MultilineText), Required(ErrorMessage = "{0} Alanı Zorunludur")]
        public string OpenAddress { get; set; }
        [Display(Name = "Aktif")]
        public bool IsActive { get; set; }
        [Display(Name = "Fatura Adresi")]
        public bool IsBillingAddress {  get; set; } //fatura adresi
        [Display(Name ="Teslimat Adresi")]
        public bool IsDeliveryAddress { get; set; } //Teslimat adresi
        [Display(Name = "Kayıt Tarihi"), ScaffoldColumn(false)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;


        [ScaffoldColumn(false)] // CRUD sayfası oluştururken bu değişkenin oluşmasını engeller
        public Guid? AddressGuid { get; set; } = Guid.NewGuid();
        public int? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
