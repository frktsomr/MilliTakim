using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MilliTakim.Models
{
    public class Magaza
    {
        public enum Beden
        {
            XS = 1,
            S = 2,
            M = 3,
            L = 4,
            XL = 5,
            XXL = 6,
        }

        [Key]
        public int urunId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Lütfen Geçerli Bir Ad giriniz")]
        [Display(Name = "Ürün Adı")]
        public string urunAdi { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Lütfen Geçerli Bir Fiyat")]
        [Display(Name = "Fiyat")]
        [RegularExpression("^[1-9]+([0-9])*$", ErrorMessage = "Lütfen Geçerli Bir Fiyat Giriniz")]
        public int fiyat { get; set; }
        [Display(Name = "Beden ")]
        public Beden beden { get; set; }
        [Display(Name = "Ürün Fotoğrafı")]
        public byte[] ProfilePicture { get; set; }
    }
}
