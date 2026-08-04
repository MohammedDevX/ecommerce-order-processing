using EcommerceSystem.Application.Abstractions.Repositories;
using EcommerceSystem.Domain.Entities;

namespace EcommerceSystem.Application.Orders.PlaceOrder
{
    public class PlaceOrderHandler(IOrderRepository orderRepository,
        ICustomerRepository customerRepository,
        IProductRepository productRepository)
    {
        public async Task Handle(PlaceOrderCommand request)
        {
            if (request.CustomerId == Guid.Empty)
                throw new ArgumentException("CustomerId is empty");

            int orderItemsCount = request.OrderItems.Count;

            if (orderItemsCount <= 0)
                throw new ArgumentException("Please select at least on product to validat the order");

            foreach (var item in request.OrderItems)
            {
                if (item.Quantity <= 0)
                    throw new ArgumentException("Quantity should be hegher than 0");
            }

            bool existCustomer = await customerRepository.IsCustomerExistAsync(request.CustomerId);

            if (!existCustomer)
                throw new ArgumentException("This customer isn't registred in our system");

            var productsIds = request.OrderItems.Select(i => i.ProductId);
            
            IEnumerable<Product> products = await productRepository.GetProducstByIdAsync(productsIds);

            if (products.Count() != orderItemsCount)
                throw new ArgumentException("Invalid items");

            Dictionary<Guid, Product> productsDictionary = products.ToDictionary(i => i.Id);

            Order order = new(request.CustomerId);

            foreach (var item in request.OrderItems)
            {
                order.AddItem(productsDictionary[item.ProductId], item.Quantity);
            }
            
            await orderRepository.SaveAsync(order);
        }
    }
}
