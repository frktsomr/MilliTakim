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
        public string urunAdi { get; set; }
        public float fiyat { get; set; }
        public string beden { get; set; }
        public byte[] ProfilePicture { get; set; }
    }
}
