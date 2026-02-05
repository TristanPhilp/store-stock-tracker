using Microsoft.EntityFrameworkCore;
using store_stock_tracker.Models;

namespace store_stock_tracker.Data
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) 
            : base(options) { }

        public DbSet<Product> Products => Set<Product>();
    }
}
