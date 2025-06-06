﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace techMADT2.Core.Entities
{
    public class Contact : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Adı"),Required(ErrorMessage ="{0} Alanı Boş Geçilmez!")]
        public string Name { get; set; }
        [Display(Name = "Soyadı"),Required(ErrorMessage = "{0} Alanı Boş Geçilmez!")]
        public string Surname { get; set; }
        [Display(Name = "Mesaj"), Required(ErrorMessage = "{0} Alanı Boş Geçilmez!")]
        public string Message { get; set; }
        

        public string? Email { get; set; }
        [Display(Name = "Telefon")]
        public string? Phone { get; set; }
        [Display(Name = "Kayıt Tarihi"), ScaffoldColumn(false)]
        public DateTime CreateDate { get; set; } = DateTime.Now;

    }
}
