﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilliTakim.Models.Contexts
{
    public class WebContext : DbContext
    {

        public WebContext(DbContextOptions<WebContext> options) : base(options)
        {

        }

        public DbSet<Futbolcu> futbolcu { get; set; }
        public DbSet<Admin> admins { get; set; }
    }
}