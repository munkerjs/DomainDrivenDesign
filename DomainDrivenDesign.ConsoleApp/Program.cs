using BenchmarkDotNet.Running;
using DomainDrivenDesign.ConsoleApp;
using MediatR;

#region Domain Events

internal class Program
{
    private static void Main(string[] args)
    {
        Order order = new Order();
        order.CreateOrder(1, "Tablet");
        order.CreateOrder(2, "Bilgisayar");
        order.CreateOrder(3, "Telefon");

        DomainEventDispacther.Dispatch(order.DomainEvents);
        Console.ReadLine();
    }
}

public class Order
{
    private readonly IMediator _mediator; // örnek olarak burada yoksa servis içinde olmalı

    public Order()
    {
    }

    public Order(IMediator mediator)
    {
        _mediator = mediator;
    }

    public int Id { get; set; }
    public string ProductName { get; set; }
    public List<IDomainEvent> DomainEvents { get; } = new List<IDomainEvent>();

    public void CreateOrder(int id, string productName)
    {
        Id = id;
        ProductName = productName;

        // TODO: Bazı işlemleri tetikleyelim. Mesela Kayıt Yapalım..
        DomainEvents.Add(new OrderCreatedEvent(id));
        _mediator.Publish(new OrderCompletedEvent(id));

    }
}

public static class DomainEventDispacther
{
    public static void Dispatch(List<IDomainEvent> events)
    {
        foreach (var domainEvent in events)
        {
            if(domainEvent is OrderCreatedEvent orderEvent)
            {
                Console.WriteLine($"Order Event çalışmaya başladı. Id: {orderEvent.OrderId}");
            }
        }
    }
}

public interface IDomainEvent
{

}

public class OrderCreatedEvent : IDomainEvent
{
    public OrderCreatedEvent(int orderId)
    {
        OrderId = orderId;
    }
    public int OrderId { get; }

}

#endregion

#region MediatR Kütüphanesi ile Domain Events İşlemleri

// TODO: Sipariş oluştuğu esnada ürünün stok bilgisini de güncelleyelim.
public class StockUpdateHandler : INotificationHandler<OrderCompletedEvent>
{
    public Task Handle(OrderCompletedEvent notification, CancellationToken cancellationToken)
    {
        // İşlemlerimizi Yapalım.



        return Task.CompletedTask;
    }
}

// TODO: Sipariş tamamlanınca birde mail gönderelim.
public class SendMailHandler : INotificationHandler<OrderCompletedEvent>
{
    public Task Handle(OrderCompletedEvent notification, CancellationToken cancellationToken)
    {
        // İşlemlerimizi Yapalım.


        return Task.CompletedTask;
    }
}

// TODO: Sipariş tamamlanınca SMS gönderelim.
public class SendSMSHandler : INotificationHandler<OrderCompletedEvent>
{
    public Task Handle(OrderCompletedEvent notification, CancellationToken cancellationToken)
    {
        // İşlemlerimizi Yapalım.


        return Task.CompletedTask;
    }
}

public class OrderCompletedEvent: INotification
{
    public OrderCompletedEvent(int ıd)
    {
        Id = ıd;
    }

    public int Id { get; }

}
#endregion

#region Benchmark Test

//BenchmarkRunner.Run<BenchmarkService>();
//Console.ReadLine();
public abstract class BaseEntity : IEquatable<BaseEntity>
{
    public Guid Id { get; init; }
    public BaseEntity(Guid id)
    {
        Id = id;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null)
        {
            return false;
        }

        if (obj is not BaseEntity entity)
        {
            return false;
        }

        if (obj.GetType() != GetType())
        {
            return false;
        }

        return entity.Id == Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public bool Equals(BaseEntity? other)
    {
        if (other == null)
        {
            return false;
        }

        if (other is not BaseEntity entity)
        {
            return false;
        }

        if (other.GetType() != GetType())
        {
            return false;
        }

        return entity.Id == Id;
    }
}

public class A : BaseEntity
{
    public A(Guid id) : base(id) { }

}

#endregion