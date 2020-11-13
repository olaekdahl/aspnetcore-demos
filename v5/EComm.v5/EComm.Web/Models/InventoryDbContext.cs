using Microsoft.EntityFrameworkCore;

namespace EComm.Web.Models
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options) { }

        public DbSet<ProductInventory> ProductInventory { get; set; }
    }
}