using EcommerceSystem.Domain.Entities;

namespace EcommerceSystem.Application.Orders.PlaceOrder
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> GetProducstByIdAsync(IEnumerable<Guid> ids);
    }
}
