using DomainDrivenDesign.Domain.Orders;
using MediatR;

namespace DomainDrivenDesign.Application.Features.Orders.GetAllOrder
{
    internal sealed class GetAllOrderHandler : IRequestHandler<GetAllOrderQuery, List<Order>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetAllOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<Order>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetAllAsync(cancellationToken);
        }
    }
}
