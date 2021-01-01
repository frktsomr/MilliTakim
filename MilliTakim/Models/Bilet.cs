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
        [Required]
        [Display(Name ="Maç Adı")]
        [DataType(DataType.Text,ErrorMessage = "Lutfen Gecerli Bir Karsilasma Adi Giriniz")]
        public string macAdi { get; set; }
        [Required]
        [Display(Name = "Bilet Fiyatı")]
        [RegularExpression("^[1-9]+$",ErrorMessage = "Lutfen Gecerli Bir Fiyat Giriniz")]
        public int biletFiyat { get; set; }
        [Required]
        [Display(Name = "Bilet Adedi")]
        [RegularExpression("^[1-9]+([0-9])*$", ErrorMessage = "Lutfen Gecerli Bir Sayi Giriniz")]
        public int biletAdet { get; set; }
        [Required]
        [Display(Name = "Maç Yeri")]
        [DataType(DataType.Text, ErrorMessage = "Lutfen Gecerli Bir Karsilasma Adi Giriniz")]
        public string macYer { get; set; }
        [Required]
        [Display(Name = "Maç Tarihi")]
        public DateTime macTarihi { get; set; }
    }
}
