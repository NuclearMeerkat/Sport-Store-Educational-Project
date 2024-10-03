using Data.Interfaces;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Data.Data
{
    public class UnitOFWork : IUnitOfWork
    {
        public SportStoreDbContext context { get; }

        public UnitOFWork(SportStoreDbContext context)
        {
            this.context = context;
            UserRepository = new UserRepository(context);
            RoleRepository = new RoleRepository(context);
            ProductRepository = new ProductRepository(context);
            ProductCategoryRepository = new ProductCategoryRepository(context);
            OrderRepository = new OrderRepository(context);
            OrderItemRepository = new OrderItemRepository(context);
        }

        public IUserRepository UserRepository { get; }

        public IRoleRepository RoleRepository { get; }

        public IProductRepository ProductRepository { get; }

        public IProductCategoryRepository ProductCategoryRepository { get; }

        public IOrderRepository OrderRepository { get; }

        public IOrderItemRepository OrderItemRepository { get; }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
