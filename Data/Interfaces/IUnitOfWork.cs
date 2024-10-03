using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }

        IRoleRepository RoleRepository { get; }

        IProductRepository ProductRepository { get; }

        IProductCategoryRepository ProductCategoryRepository { get; }

        IOrderRepository OrderRepository { get; }

        IOrderItemRepository OrderItemRepository { get; }

        Task SaveAsync();
    }
}
