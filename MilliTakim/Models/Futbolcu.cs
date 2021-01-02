using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MilliTakim.Models
{
    public class Futbolcu
    {

        [Key]
        public int playerId { get; set; }
        [Display(Name = "Adı")]
        [DataType(DataType.Text , ErrorMessage = "Lütfen Geçerli Bir Ad Giriniz")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Lütfen Geçerli Bir Ad Giriniz"), StringLength(20)]
        public string futbolcuAd { get; set; }
        [Display(Name = "Soyadı")]
        [DataType(DataType.Text, ErrorMessage = "Lütfen Geçerli Bir Soyad Giriniz")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Lütfen Geçerli Bir Soyad Giriniz"), StringLength(20)]
        public string futbolcuSoyad { get; set; }

        [Display(Name = "Instagram")]
        [DataType(DataType.Url, ErrorMessage = "Lütfen Geçerli Bir Link Giriniz")]
        public string futbolcuInsta { get; set; }

        [Display(Name = "Twitter")]
        [DataType(DataType.Url, ErrorMessage = "Lütfen Geçerli Bir Link Giriniz")]
        public string futbolcuTwitter { get; set; }

        [Required(ErrorMessage = "Lütfen Bir Yaş Giriniz")]
        [Display(Name = "Yaş")]
        [Range(16,100,ErrorMessage = "Lütfen Geçerli Bir Yaş Giriniz (16-100)")]
        public int futbolcuYas { get; set; }

        [Required(ErrorMessage = "Lütfen Geçerli Bir Değer Giriniz")]
        [Display(Name = "Market Değeri")]
        [RegularExpression("^[1-9]+([0-9])*$", ErrorMessage = "Lütfen Geçerli Bir Değer Giriniz")]
        public long futbolcuMarketDegeri { get; set; }
        [Display(Name = "Profil Fotoğrafı")]
        public byte[] ProfilePicture { get; set; }

    }
}
