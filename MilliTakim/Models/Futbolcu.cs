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
        [Required]
        [Display(Name = "Adı")]
        public string futbolcuAd { get; set; }
        [Required]
        [Display(Name = "Soyadı")]
        public string futbolcuSoyad { get; set; }
        [Display(Name = "Instagram")]
        public string futbolcuInsta { get; set; }
        [Display(Name = "Twitter")]
        public string futbolcuTwitter { get; set; }
        [Required]
        [Display(Name = "Yaş")]
        public int futbolcuYas { get; set; }
        [Display(Name = "Market Değeri")]
        public long futbolcuMarketDegeri { get; set; }

        public byte[] ProfilePicture { get; set; }

    }
}
