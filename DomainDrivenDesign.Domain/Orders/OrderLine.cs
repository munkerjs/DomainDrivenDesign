﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Products;
using DomainDrivenDesign.Domain.Shared;

namespace DomainDrivenDesign.Domain.Orders
{
    public sealed class OrderLine : BaseEntity
    {
        private OrderLine(Guid id) : base(id) { } // add-migration yaparken hata atmaması için
        public OrderLine(Guid id, Guid orderId, Guid productId, int quantity, Money price) : base(id)
        {
            ProductId = productId;
            Quantity = quantity;
            Price = price;
        }

        public Guid OrderId { get; private set; }
        public Guid ProductId { get; private set; }
        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public Money Price { get; private set; }
    }
}
