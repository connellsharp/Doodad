using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Doodad.Cqrs.DomainEvents
{
    public class DomainEventNotificationHandler<TDomainEvent> : INotificationHandler<DomainEventNotification<TDomainEvent>>
        where TDomainEvent : IDomainEvent
    {
        private readonly IEnumerable<IDomainEventHandler<TDomainEvent>> _domainEventHandlers;

        public DomainEventNotificationHandler(IEnumerable<IDomainEventHandler<TDomainEvent>> domainEventHandlers)
        {
            _domainEventHandlers = domainEventHandlers;
        }

        public async Task Handle(DomainEventNotification<TDomainEvent> notification, CancellationToken cancellationToken)
        {
            foreach(var domainEventHandler in _domainEventHandlers)
            {
                await domainEventHandler.Handle(notification.DomainEvent);
            }
        }
    }
}
