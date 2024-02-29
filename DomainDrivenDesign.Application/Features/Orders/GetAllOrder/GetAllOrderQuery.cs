using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Orders;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Application.Features.Orders.GetAllOrder
{
    public sealed record class GetAllOrderQuery() : IRequest<List<Order>>;
}
