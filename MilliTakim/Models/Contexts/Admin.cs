using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MilliTakim.Models.Contexts
{
    public class Admin
    {
        public int adminId { get; set; }

        [Column(TypeName = "Varchar(20)")]
        public string adminAd { get; set; }

        public string adminSifre { get; set; }

    }
}
