using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MilliTakim.Areas.Identity.Data
{
    public class AuthUser : IdentityUser
    {
        [Column(TypeName = "Varchar(20)")]
        [RegularExpression("^([a-zA-Z]+\\s)*[a-zA-Z]+$",ErrorMessage = "Lütfen Geçerli Bir Ad Giriniz")]
        public string Ad { get; set; }

        [Column(TypeName = "Varchar(20)")]
        [RegularExpression("^([a-zA-Z]+\\s)*[a-zA-Z]+$", ErrorMessage = "Lütfen Geçerli Bir Soyad Giriniz")]
        public string Soyad { get; set; }

        public byte[] ProfilePicture { get; set; }
    }
}
