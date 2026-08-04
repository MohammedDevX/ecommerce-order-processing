using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace EcommerceSystem.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; init; }
        public required string FullName { get; init; }
        public required string Email { get; init; }

        [SetsRequiredMembers]
        public Customer(string fullName, string email)
        {
            if (fullName.Trim().Length == 0 || email.Trim().Length == 0)
                throw new ArgumentException("Email and full name are required");

            Id = Guid.NewGuid();
            FullName = fullName;
            Email = email;
        }
    }
}
