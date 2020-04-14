using System;
using System.Threading.Tasks;
using MediatR;

namespace Doodad.Cqrs.Subscriber
{
    public interface IMediatorSubscriber
    {
        void Subscribe<TNotification>(Func<TNotification, Task> handler) where TNotification : INotification;
        void SubscribeAll(Func<INotification, Task> handler);

        void Unsubscribe<TNotification>(Func<TNotification, Task> handler) where TNotification : INotification;
        void UnsubscribeAll(Func<INotification, Task> handleMediatorEvent);
    }
}
