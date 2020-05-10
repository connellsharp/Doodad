using MediatR;

namespace Doodad.Cqrs.DomainEvents
{
    public class DomainEventNotification<TEvent> : INotification
        where TEvent : IDomainEvent
    {
        public DomainEventNotification(TEvent domainEvent)
        {
            DomainEvent = domainEvent;
        }
        
        public TEvent DomainEvent { get; }
    }
}
