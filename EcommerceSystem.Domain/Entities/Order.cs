using EcommerceSystem.Domain.Enums;

namespace EcommerceSystem.Domain.Entities
{
     public class Order
    {
        public Guid Id { get; init; }
        public Guid CustomerId { get; set; }
        public OrderStatus OrderStatus { get; private set; }
        private readonly List<OrderItem> _items = new();
        public IReadOnlyCollection<OrderItem> Items => _items;
        public decimal TotalPrice => _items.Sum(i => i.Total);

        public void CangeOrderStatus(OrderStatus status)
        {
            if (status != OrderStatus)
            {
                OrderStatus = status;
            }
        }

        public void AddItem(Product product, int quantity)
        {
            if (!product.IsActive)
                throw new InvalidOperationException($"Operation invalid the product with Id : {product.Id} is inactive");

            OrderItem? item = Items.FirstOrDefault(i => i.ProductId == product.Id);

            if (item != null) {
                item.IncreaseQuantity(quantity);
            } else
            {
                item = new(product.Id, product.Price, quantity);
                _items.Add(item);
            }
        }
    }
}