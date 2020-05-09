using System;

namespace Doodad.Cqrs.Behaviors
{
    internal static class DomainEventNotificationWrapper
    {
        public static DomainEventNotification<TEvent> Wrap<TEvent>(TEvent domainEvent)
            where TEvent : IDomainEvent
        {
            return new DomainEventNotification<TEvent>(domainEvent);
        }

        public static object Wrap(IDomainEvent domainEvent)
        {
            var eventType = domainEvent.GetType();
            var notificationType = typeof(DomainEventNotification<>).MakeGenericType(eventType);
            var notification = Activator.CreateInstance(notificationType, domainEvent);
            return notification;
        }
    }
}
