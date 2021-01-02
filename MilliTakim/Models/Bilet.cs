using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MilliTakim.Models
{
    public class Bilet
    {
        [Key]
        public int biletId { get; set; }
        [Required(ErrorMessage = "Lütfen Geçerli Bir Ad Giriniz")]
        [Display(Name ="Maç Adı")]
        [DataType(DataType.Text,ErrorMessage = "Lütfen Geçerli Bir Karşılaşma Adı Giriniz")]
        public string macAdi { get; set; }
        [Required(ErrorMessage = "Lütfen Geçerli Bir Fiyat Giriniz")]
        [Display(Name = "Bilet Fiyatı")]
        [RegularExpression("^[1-9]+([0-9])*$", ErrorMessage = "Lütfen Geçerli Bir Fiyat Giriniz")]
        public int biletFiyat { get; set; }
        [Required(ErrorMessage = "Lütfen Geçerli Bir Sayı Giriniz")]
        [Display(Name = "Bilet Adedi")]
        [RegularExpression("^[1-9]+([0-9])*$", ErrorMessage = "Lütfen Geçerli Bir Sayı Giriniz")]
        public int biletAdet { get; set; }
        [Required(ErrorMessage = "Lütfen Geçerli Bir Maç Yeri Giriniz")]
        [Display(Name = "Maç Yeri")]
        [DataType(DataType.Text, ErrorMessage = "Lütfen Geçerli Bir Maç Yeri Giriniz")]
        public string macYer { get; set; }
        [Required(ErrorMessage = "Lütfen Geçerli Bir Tarih Giriniz")]
        [Display(Name = "Maç Tarihi")]
        public DateTime macTarihi { get; set; }
    }
}
