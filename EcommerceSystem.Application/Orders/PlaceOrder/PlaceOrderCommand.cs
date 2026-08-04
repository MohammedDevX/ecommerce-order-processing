namespace EcommerceSystem.Application.Orders.PlaceOrder
{
    public record PlaceOrderCommand(Guid CustomerId, List<PlaceOrderItem> OrderItems)
    {
    }
}
