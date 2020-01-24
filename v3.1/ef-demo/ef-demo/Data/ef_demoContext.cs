using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ef_demo.Models;

namespace ef_demo.Data
{
    public class ef_demoContext : DbContext
    {
        public ef_demoContext (DbContextOptions<ef_demoContext> options)
            : base(options)
        {
        }

        public DbSet<ef_demo.Models.Product> Product { get; set; }
    }
}
