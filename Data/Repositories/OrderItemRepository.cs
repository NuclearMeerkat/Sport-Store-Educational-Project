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
    public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(SportStoreDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<OrderItem>> GetAllWithDetailsAsync()
        {
            return await context.Set<OrderItem>()
                .Include(r => r.Order)
                .Include(p => p.Product)
                    .ThenInclude(pc => pc.ProductCategory)
                .ToListAsync();
        }
    }
}
