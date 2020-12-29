using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MilliTakim.Models
{
    public class Magaza
    {
        [Key]
        public int urunId { get; set; }
        public string urunAdi { get; set; }
        public float fiyat { get; set; }
        public string beden { get; set; }
        public byte[] ProfilePicture { get; set; }
    }
}
