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
        public Order(Guid id) : base(id)
        {
        }
        public string OrderNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public OrderStatusEnum Status { get; set; }
        public ICollection<OrderLine> OrderLines { get; set; }
    }
}

