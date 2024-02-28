using DomainDrivenDesign.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Domain.Orders
{
    public sealed class Order : BaseEntity
    {
        public Order(Guid id, string orderNumber, DateTime createdAt, OrderStatusEnum status, ICollection<OrderLine> orderLines) : base(id)
        {
            OrderNumber = orderNumber;
            CreatedAt = createdAt;
            Status = status;
            OrderLines = orderLines;
        }

        public string OrderNumber { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public OrderStatusEnum Status { get; private set; }
        public ICollection<OrderLine> OrderLines { get; private set; }
    }
}

