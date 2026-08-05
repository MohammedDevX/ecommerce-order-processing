using EcommerceSystem.Application.Abstractions.Repositories;
using EcommerceSystem.Domain.Entities;
using EcommerceSystem.Infrastructure.Data;

namespace EcommerceSystem.Infrastructure.Repositories
{
    public class StaticOrderRepository(StaticData data) : IOrderRepository
    {
        public Task<IEnumerable<Order>> GetOrdersAsync(Guid CustomerId)
        {
            var orders = data.Orders.Where(o => o.CustomerId == CustomerId).ToList();
            return Task.FromResult(orders.AsEnumerable());
        }

        public Task SaveAsync(Order order)
        {
            data.Orders.Add(order);
            return Task.CompletedTask;
        }
    }
}
