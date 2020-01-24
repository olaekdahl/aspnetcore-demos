using Ecomm.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecomm.Data
{
    public class ProductDbCtx : DbContext
    {
        public ProductDbCtx(DbContextOptions<ProductDbCtx> options)
           : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
