using EcommerceSystem.Domain.Entities;

namespace EcommerceSystem.Application.Abstractions.Repositories
{
    public interface IOrderRepository
    {
        public Task SaveAsync(Order order);
    }
}
