using EcommerceSystem.Domain.Enums;

namespace EcommerceSystem.Domain.Entities
{
     public class Order
    {
        public Guid Id { get; init; }
        public Guid CustomerId { get; init; }
        public OrderStatus OrderStatus { get; private set; }
        private readonly List<OrderItem> _items = new();
        public IReadOnlyCollection<OrderItem> Items => _items;
        public decimal TotalPrice => _items.Sum(i => i.Total);

        public Order(Guid customerId)
        {
            Id = new Guid();
            CustomerId = customerId;
            OrderStatus = OrderStatus.Pending;
        }

        public void MarkAsPaid()
        {
            if (OrderStatus != OrderStatus.Pending)
                throw new InvalidOperationException("Can't change order status to paid if the order isn't pending");

            OrderStatus = OrderStatus.Paid;
        }

        public void AddItem(Product product, int quantity)
        {
            if (OrderStatus != OrderStatus.Pending)
                throw new InvalidOperationException("Can't change the quantity because the order isn't pending");

            if (!product.IsActive)
                throw new InvalidOperationException($"Operation invalid the product with Id : {product.Id} is inactive");

            OrderItem? item = FindOrderItem(product.Id);

            if (item != null) {
                item.AddQuantity(quantity);
            } else
            {
                item = new(product.Id, product.Price, quantity);
                _items.Add(item);
            }
        }

        public void ChangeItemQuantity(Guid productId, int quantity)
        {
            if (OrderStatus != OrderStatus.Pending)
                throw new InvalidOperationException("Can't change the quantity because the order isn't pending");

            var item = FindOrderItem(productId);

            if (item != null)
                item.ChangeQuantiy(quantity);
        }

        private OrderItem? FindOrderItem(Guid productId)
        {
            return _items.FirstOrDefault(i => i.ProductId == productId);
        }
    }
}