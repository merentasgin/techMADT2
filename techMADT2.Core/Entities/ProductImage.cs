using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace techMADT2.Core.Entities
{
    public class ProductImage: IEntity
    {
        public int Id { get; set; }
        [Display(Name = " Resim Adı"),StringLength(240)]
        public string? Name { get; set; }
        [Display(Name = " Resim Açıklama (Alt Tagı)"), StringLength(240)]
        public string? Alt { get; set; }
        [Display(Name = "Ürün")]
        public int? ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
