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
        [DataType(DataType.Text,ErrorMessage = "Lutfen Gecerli Bir Karsilasma Adi Giriniz")]
        public string macAdi { get; set; }
        [Required]
        [RegularExpression("^[1-9]+$",ErrorMessage = "Lutfen Gecerli Bir Fiyat Giriniz")]
        public int biletFiyat { get; set; }
        [Required]
        [RegularExpression("^[1-9]+$", ErrorMessage = "Lutfen Gecerli Bir Sayi Giriniz")]
        public int biletAdet { get; set; }
        [Required]
        [DataType(DataType.Text, ErrorMessage = "Lutfen Gecerli Bir Karsilasma Adi Giriniz")]
        public string macYer { get; set; }
        [Required]
        public DateTime macTarihi { get; set; }
    }
}
