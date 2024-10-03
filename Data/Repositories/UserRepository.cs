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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(SportStoreDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<User>> GetAllWithDetailsAsync()
        {
            return await context.Set<User>()
                .Include(p => p.Role)
                .Include(r => r.Orders)
                    .ThenInclude(rd => rd.OrderItems)
                .ToListAsync();
        }

        public async Task<User> GetByIdWithDetailsAsync(int id)
        {
            return await context.Set<User>()
                .Include(p => p.Role)
                .Include(r => r.Orders)
                    .ThenInclude(rd => rd.OrderItems)
                .FirstAsync(p => p.Id == id);
        }
    }
}
