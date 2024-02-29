using MediatR;

namespace DomainDrivenDesign.Domain.Users.Events
{
    public sealed class SendRegisterEmailEvent : INotificationHandler<UserDomainEvent>
    {
        public Task Handle(UserDomainEvent notification, CancellationToken cancellationToken)
        {
            // TODO : Üye kaydı sonrası email gönderim işlemlerini tamamla.

            return Task.CompletedTask;
        }
    }
}
