using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace SportsStore.Models
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options)
            : base(options)
        {
        }

        public StoreDbContext()
        {
            
        }

        public DbSet<Product> Products => this.Set<Product>();

        public DbSet<Order> Orders => this.Set<Order>();
    }
}
