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
        public string macAdi { get; set; }
        public int biletFiyat { get; set; }
        public int biletAdet { get; set; }
        public string macYer { get; set; }
        public string macSaati { get; set; }
        public DateTime macTarihi { get; set; }
    }
}
