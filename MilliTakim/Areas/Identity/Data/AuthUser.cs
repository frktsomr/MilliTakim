using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MilliTakim.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the AuthUser class
    public class AuthUser : IdentityUser
    {
        [Column(TypeName = "Varchar(20)")]
        [RegularExpression("^([a-zA-Z]+\\s)*[a-zA-Z]+$")]
        public string Ad { get; set; }

        [Column(TypeName = "Varchar(20)")]
        [RegularExpression("^([a-zA-Z]+\\s)*[a-zA-Z]+$")]
        public string Soyad { get; set; }

       // [Column(TypeName = "ByteData")]
        public byte[] ProfilePicture { get; set; }
    }
}
