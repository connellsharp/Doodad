using MediatR;

namespace Doodad.Cqrs.Behaviors
{
    public class DomainEventNotification<TEvent> : INotification
        where TEvent : IDomainEvent
    {
        internal DomainEventNotification(TEvent domainEvent)
        {
            DomainEvent = domainEvent;
        }
        
        public TEvent DomainEvent { get; }
    }
}
