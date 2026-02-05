using Microsoft.EntityFrameworkCore;
using store_stock_tracker.Models;

namespace store_stock_tracker.Data
{
    //Sets a database to be structured based on the Product model.
    //Used by Entity Framework Core
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options)
            : base(options) { }

        public DbSet<Product> Products => Set<Product>();
    }
}
