using EcommerceSystem.Application.Abstractions.Repositories;
using EcommerceSystem.Application.Orders.PlaceOrder;
using EcommerceSystem.Domain.Entities;
using EcommerceSystem.Infrastructure.Data;
using EcommerceSystem.Infrastructure.Repositories;

Customer customer = new("Bakhtaoui Mohammed", "mohammed@gmail.com");

StaticData data = new();

StaticDataSeed dataSeed = new(data);

dataSeed.Seed();

IProductRepository productRepository = new StaticProductRepository(data);

var products = await productRepository.GetProductsAsync();
var productsList = products.ToList();

foreach (var item in products)
{
    Console.WriteLine(item.Name);
}

Order order = new(customer.Id);

foreach (var item in products)
{
    order.AddItem(item, 2);
}

IOrderRepository orderRepository = new StaticOrderRepository(data);

await orderRepository.SaveAsync(order);

foreach (var item in await orderRepository.GetOrdersAsync(customer.Id))
{
    foreach (var item1 in item.Items)
    {
        Console.WriteLine($"Product Id : {item1.ProductId} | quantity : {item1.Quantity}");
    }
}


var customer1 = data.Customers.First();

//PlaceOrderItem placeOrderItem = new(, 5);

//PlaceOrderCommand placeOrderCommand = new(customer1.Id, );