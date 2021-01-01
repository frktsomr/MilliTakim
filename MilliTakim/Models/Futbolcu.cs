using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MilliTakim.Models
{
    public class Futbolcu
    {
        public enum Mevki
        {
            Kaleci = 1,
            Defans = 2,
            Ortasaha = 3,
            Forvet = 4
        }

        [Key]
        public int playerId { get; set; }
        [Display(Name = "Adı")]
        [DataType(DataType.Text , ErrorMessage = "Lutfen Gecerli bir Ad giriniz")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Lutfen Gecerli bir Ad giriniz"), StringLength(20, ErrorMessage = "Lutfen Gecerli bir Ad giriniz")]
        public string futbolcuAd { get; set; }
        [Display(Name = "Soyadı")]
        [DataType(DataType.Text, ErrorMessage = "Lutfen Gecerli bir Ad giriniz")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Lutfen Gecerli bir Soyadi giriniz"), StringLength(20, ErrorMessage = "Lutfen Gecerli bir Soyadi giriniz")]
        public string futbolcuSoyad { get; set; }
        [Display(Name = "Instagram")]
        [DataType(DataType.Url, ErrorMessage = "Gecerli Bir Link Giriniz")]
        public string futbolcuInsta { get; set; }
        [Display(Name = "Twitter")]
        [DataType(DataType.Url, ErrorMessage = "Gecerli Bir Link Giriniz")]
        public string futbolcuTwitter { get; set; }
        [Required]
        [Display(Name = "Yaş")]
        [Range(16,100,ErrorMessage = "Lutfen Gecerli Bir Yas Giriniz (16-100)")]

        public int futbolcuYas { get; set; }
        [Required]
        [EnumDataType(typeof(Mevki))]
        [Display(Name = "Mevki")]
        public Mevki futbolcuMevki { get; set; }

        [Display(Name = "Market Değeri")]
        [RegularExpression("^[1-9]+([0-9])*$", ErrorMessage = "Lutfen Gecerli Bir Fiyat Giriniz")]
        public long futbolcuMarketDegeri { get; set; }
        public byte[] ProfilePicture { get; set; }

    }
}
