using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_app.Shared.Models;

namespace web_app.DAL
{
    public class ECommDbContext : DbContext
    {
        public ECommDbContext(DbContextOptions<ECommDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<TopCustomer> TopCustomer { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
    }
}
