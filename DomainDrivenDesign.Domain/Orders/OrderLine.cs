using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Products;

namespace DomainDrivenDesign.Domain.Orders
{
    public sealed class OrderLine : BaseEntity
    {
        public OrderLine(Guid id) : base(id)
        {
        }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
    }
}
