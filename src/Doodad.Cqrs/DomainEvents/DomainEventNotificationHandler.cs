using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Doodad.Cqrs.DomainEvents
{
    public class DomainEventNotificationHandler<TNotification, TDomainEvent> : INotificationHandler<TNotification>
        where TNotification : DomainEventNotification<TDomainEvent>
        where TDomainEvent : IDomainEvent
    {
        private readonly IDomainEventHandler<TDomainEvent> _domainEventHandler;

        public DomainEventNotificationHandler(IDomainEventHandler<TDomainEvent> domainEventHandler)
        {
            _domainEventHandler = domainEventHandler;
        }

        public Task Handle(TNotification notification, CancellationToken cancellationToken)
        {
            return _domainEventHandler.Handle(notification.DomainEvent);
        }
    }
}
