using EcommerceSystem.Application.Orders.PlaceOrder;
using EcommerceSystem.Infrastructure.Data;

namespace EcommerceSystem.Infrastructure.Repositories
{
    public class StaticCustomerRepository(StaticData data) : ICustomerRepository
    {
        public Task<bool> IsCustomerExistAsync(Guid id)
        {
            var customer = data.Customers.Any(c => c.Id == id);

            if (!customer)
                return Task.FromResult(false);

            return Task.FromResult(true);
        }
    }
}
