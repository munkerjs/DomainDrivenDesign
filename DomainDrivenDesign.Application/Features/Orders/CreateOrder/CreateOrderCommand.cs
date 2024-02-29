using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DomainDrivenDesign.Domain.Orders.Order;

namespace DomainDrivenDesign.Application.Features.Orders.CreateOrder
{
    public sealed record class CreateOrderCommand(List<CreateOrderDto> CreateOrderDtos) : IRequest;
}
