using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Domain.Orders.Events
{
    public sealed class SendOrderEmailEvent : INotificationHandler<OrderDomainEvent>
    {
        public Task Handle(OrderDomainEvent notification, CancellationToken cancellationToken)
        {
            // TODO : Mail Gönderim İşlemlerini Tamamla

            return Task.CompletedTask;
        }
    }
}
