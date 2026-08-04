using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace EcommerceSystem.Domain.Entities
{
     public class Product
    {
        public Guid Id { get; init; }
        public required string Name { get; init; }
        public decimal Price { get; private set; }
        public bool IsActive { get; private set; } = true;

        [SetsRequiredMembers] // This attribute means that the constructor initialise the properties that have required
        public Product(string name, decimal price)
        {
            if (price <= 0)
            {
                throw new ArgumentException("The price should be heighter than 0");
            }

            Id = Guid.NewGuid();
            Name = name;
            Price = price;
        }

        public void ChangePrice(decimal newPrice)
        {
            if (IsActive == false)
                throw new Exception($"You cant change the price, product with Id : {Id} is inactive");

            if (newPrice <= 0)
            {
                throw new ArgumentException("The price should be heighter than 0");
            }

            Price = newPrice;
        }

        public void Activate() => IsActive = true;

        public void Desactivate() => IsActive = false;
    }
}