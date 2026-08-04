using EcommerceSystem.Domain.Entities;

namespace EcommerceSystem.Infrastructure.Data
{
    public class StaticData
    {
        public List<Product> Products { get; } = [];
        public List<Customer> Customers { get; } = [];
        public List<Order> Orders { get; } = [];
    }
}
