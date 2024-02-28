namespace DomainDrivenDesign.Domain.Orders
{
    public sealed partial class Order
    {
        public sealed record CreateOrderDto(Guid ProductId, int Quantity, decimal Amaunt, string Currency);
    }
}

