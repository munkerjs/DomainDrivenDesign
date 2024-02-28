﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DomainDrivenDesign.Domain.Orders.Order;

namespace DomainDrivenDesign.Domain.Orders
{
    public interface IOrderRepository
    {
        Task CreateAsync(List<CreateOrderDto> createOrderDtos, CancellationToken cancellationToken = default);
        Task<List<Order>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
