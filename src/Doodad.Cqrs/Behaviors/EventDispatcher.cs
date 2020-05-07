using System.Threading.Tasks;
using MediatR;

namespace Doodad.Cqrs.Behaviors
{
    public class EventDispatcher : IEventDispatcher
    {
        private readonly IMediator _mediator;
        private readonly IDomainEventQueue _eventQueue;

        public EventDispatcher(IMediator mediator, IDomainEventQueue eventQueue)
        {
            _mediator = mediator;
            _eventQueue = eventQueue;
        }

        public async Task DispatchEventsAsync()
        {
            while(true)
            {
                var events = _eventQueue.DequeueDomainEvents();

                if(events.Count == 0)
                    return;
                    
                foreach(var evnt in events)
                {
                    await _mediator.Publish(evnt);
                }
            }
        }
    }
}
