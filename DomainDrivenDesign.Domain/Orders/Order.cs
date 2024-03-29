﻿using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Domain.Orders
{
    public sealed partial class Order : BaseEntity
    {
        private Order(Guid id) : base(id) { }  // add-migration yaparken hata atmaması için
        public Order(Guid id, string orderNumber, DateTime createdAt, OrderStatusEnum status) : base(id)
        {
            OrderNumber = orderNumber;
            CreatedAt = createdAt;
            Status = status;
        }

        public string OrderNumber { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public OrderStatusEnum Status { get; private set; }
        public ICollection<OrderLine> OrderLines { get; private set; } = new List<OrderLine>();

        public void CreateOrder (List<CreateOrderDto> CreateOrderDtos)
        {
            foreach (var item in CreateOrderDtos) 
            {
                if(item.Quantity < 1)
                {
                    throw new ArgumentException("Sipariş adedi 1'den az olamaz!");
                }

                // TODO: Diğer kuralları belirle.

                OrderLine orderLine = new(
                    Guid.NewGuid(),
                    Id,
                    item.ProductId,
                    item.Quantity,
                    new(item.Amaunt, Currency.FromCode(item.Currency))
                );

                OrderLines.Add(orderLine);
            }
        }

        public void RemoveOrderLine(Guid orderLineId)
        {
            var orderline = OrderLines.FirstOrDefault(x=> x.Id == orderLineId);
            if (orderline == null)
                throw new ArgumentException("Silmek istediğiniz sipariş kaydı bulunamadı.");

            OrderLines.Remove(orderline);
        }
    }
}

