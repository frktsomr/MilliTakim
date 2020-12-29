using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilliTakim.Models
{
    public class WebContext : DbContext
    {

        public WebContext(DbContextOptions<WebContext> options) : base(options)
        {

        }
        public DbSet<Futbolcu> futbolcu { get; set; }
        public DbSet<Bilet> bilet { get; set; }
        public DbSet<Magaza> magaza { get; set; }
    }
}
