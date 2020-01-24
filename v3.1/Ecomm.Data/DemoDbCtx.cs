using Ecomm.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecomm.Data
{
    public class DemoDbCtx : DbContext
    {
        public DemoDbCtx(DbContextOptions<DemoDbCtx> options)
            :base(options)
        {

        }
        public DbSet<Person> People { get; set; }
    }
}
