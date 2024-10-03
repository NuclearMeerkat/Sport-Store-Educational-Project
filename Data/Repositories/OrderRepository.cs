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
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(SportStoreDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Order>> GetAllWithDetailsAsync()
        {
            return await context.Set<Order>()
                .Include(pc => pc.User)
                    .ThenInclude(p => p.Role)
                .Include(rd => rd.OrderItems)
                    .ThenInclude(rd => rd.Product)
                        .ThenInclude(pc => pc.ProductCategory)
                .ToListAsync();
        }

        public async Task<Order> GetByIdWithDetailsAsync(int id)
        {
            return await context.Set<Order>()
                .Include(pc => pc.User)
                    .ThenInclude(p => p.Role)
                .Include(rd => rd.OrderItems)
                    .ThenInclude(rd => rd.Product)
                        .ThenInclude(pc => pc.ProductCategory)
                .FirstAsync(p => p.Id == id);
        }
    }
}
