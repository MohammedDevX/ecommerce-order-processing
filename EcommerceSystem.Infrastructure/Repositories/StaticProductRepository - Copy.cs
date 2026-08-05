using EcommerceSystem.Application.Orders.PlaceOrder;
using EcommerceSystem.Domain.Entities;
using EcommerceSystem.Infrastructure.Data;

namespace EcommerceSystem.Infrastructure.Repositories
{
    public class StaticProductRepository(StaticData data) : IProductRepository
    {
        public Task<IEnumerable<Product>> GetProducstByIdAsync(IEnumerable<Guid> ids)
        {
            HashSet<Guid> idsHashSet = ids.ToHashSet();
            // The complexity of using Contains in HashSet is O(1), in List is O(N)
            var products = data.Products.Where(p => idsHashSet.Contains(p.Id));

            return Task.FromResult(products);
        }
    }
}
