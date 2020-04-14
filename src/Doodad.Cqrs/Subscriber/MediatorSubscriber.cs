using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using MediatR;

namespace Doodad.Cqrs.Subscriber
{
    public class MediatorSubscriber : IMediatorSubscriber
    {
        private readonly ConcurrentDictionary<Type, object> _handlers = 
                     new ConcurrentDictionary<Type, object>();

        private HandlerCollection<T> GetCollection<T>()
        {
            return _handlers.GetOrAdd(typeof(T), t => new HandlerCollection<T>()) as HandlerCollection<T>;
        }

        public void Subscribe<TNotification>(Func<TNotification, Task> handler)
            where TNotification : INotification
        {
            GetCollection<TNotification>().Subscribe(handler);
        }

        public void SubscribeAll(Func<INotification, Task> handler)
        {
            GetCollection<INotification>().Subscribe(handler);
        }

        public void Unsubscribe<TNotification>(Func<TNotification, Task> handler)
            where TNotification : INotification
        {
            GetCollection<TNotification>().Unsubscribe(handler);
        }

        public void UnsubscribeAll(Func<INotification, Task> handler)
        {
            GetCollection<INotification>().Unsubscribe(handler);
        }

        internal async Task Publish<TNotification>(TNotification notification)
            where TNotification : INotification
        {
            await GetCollection<TNotification>().Publish(notification);
            await GetCollection<INotification>().Publish(notification);
        }
    }
}
