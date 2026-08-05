using EcommerceSystem.Domain.Entities;

namespace EcommerceSystem.Infrastructure.Data
{
    public class StaticDataSeed(StaticData data)
    {
        public void Seed()
        {
            // Customers 
            var ahmed = new Customer("Ahmed", "ahmed@gmail.com");
            var sara = new Customer("Sara", "sara@gmail.com");
            var youssef = new Customer("Youssef", "youssef@gmail.com");
            var imane = new Customer("Imane", "imane@gmail.com");
            var omar = new Customer("Omar", "omar@gmail.com");

            data.Customers.AddRange(ahmed, sara, youssef, imane, omar);

            // Products
            var castrol = new Product("Castrol Edge 5W30", 450m);
            var total = new Product("Total Quartz 9000", 390m);
            var shell = new Product("Shell Helix Ultra", 420m);
            var oilFilter = new Product("Bosch Oil Filter", 120m);
            var airFilter = new Product("Air Filter", 95m);
            var brakePads = new Product("Brake Pads", 650m);

            //castrol.Desactivate();

            data.Products.AddRange(castrol, total, shell, oilFilter, airFilter, brakePads);

            // Clear orders

            data.Orders.Clear();
        }
    }
}
