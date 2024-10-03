using Data.Data;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(SportStoreDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetAllWithDetailsAsync()
        {
            return await context.Set<Product>()
                .Include(pc => pc.ProductCategory)
                .Include(rd => rd.OrderItems)
                .ToListAsync();
        }

        public async Task<Product> GetByIdWithDetailsAsync(int id)
        {
            return await context.Set<Product>()
                .Include (pc => pc.ProductCategory)
                .Include(rd => rd.OrderItems)
                .FirstAsync(p => p.Id == id);
        }
    }
}
