using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

namespace Doodad.Cqrs.Subscriber
{
    internal class HandlerCollection<T>
    {
        private ConcurrentBag<Func<T, Task>> _handlers = new ConcurrentBag<Func<T, Task>>();
        
        public void Subscribe(Func<T, Task> handler)
        {
            _handlers.Add(handler);
        }
        
        public void Unsubscribe(Func<T, Task> handler)
        {
            _handlers = new ConcurrentBag<Func<T, Task>>(_handlers.Where(h => h != handler));
        }
        
        public async Task Publish(T notification)
        {
            foreach(var handler in _handlers)
            {
                await handler(notification);
            }
        }
    }
}
