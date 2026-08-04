using EcommerceSystem.Domain.Entities;

namespace EcommerceSystem.Application.Orders.PlaceOrder
{
    public interface ICustomerRepository
    {
        public Task<bool> IsCustomerExistAsync(Guid id);
    }
}
