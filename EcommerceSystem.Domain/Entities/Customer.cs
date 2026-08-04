using System.ComponentModel.DataAnnotations;

namespace EcommerceSystem.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; init; }
        public required string FullName { get; init; }
        public required string Email { get; init; }
    }
}
