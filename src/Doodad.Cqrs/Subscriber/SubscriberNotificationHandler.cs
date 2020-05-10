using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Doodad.Cqrs.Subscriber
{
    public class SubscriberNotificationHandler<TNotification> : INotificationHandler<TNotification>
        where TNotification : INotification
    {
        private readonly MediatorSubscriber _subscriber;

        public SubscriberNotificationHandler(MediatorSubscriber subscriber)
        {
            _subscriber = subscriber;
        }

        public Task Handle(TNotification notification, CancellationToken cancellationToken)
        {
            return _subscriber.Publish(notification);
        }
    }
}
