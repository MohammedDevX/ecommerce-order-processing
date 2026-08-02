namespace EcommerceSystem.Domain.Entities
{
     public class OrderItem
    {
        public Guid Id { get; init; }
        public Guid ProductId { get; init; }
        public decimal Price { get; init; }
        public int Quantity { get; private set; }
        public decimal Total => Price * Quantity;

        public OrderItem(Guid productId, decimal price, int quantity)
        {
            if (price <= 0 || quantity <= 0)
                throw new ArgumentException("Price and quantity should be heigher than 0");
            Id = Guid.NewGuid();
            ProductId = productId;
            Price = price;
            Quantity = quantity;
        }

        public void AddQuantity(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity should be heigher than 0");

            Quantity += quantity;
        }

        public void ChangeQuantiy(int newQuantity)
        {
            if (newQuantity <= 0)
                throw new ArgumentException("Quantity should be heigher than 0");

            Quantity = newQuantity;
        }
    }
}