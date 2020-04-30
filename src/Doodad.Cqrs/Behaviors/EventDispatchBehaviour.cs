using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Doodad.Cqrs.Behaviors
{
    public class EventDispatchBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private IEventDispatcher _eventDispatcher;

        public EventDispatchBehaviour(IEventDispatcher eventDispatcher)
        {
            _eventDispatcher = eventDispatcher;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var response = await next();
            
            await _eventDispatcher.DispatchEventsAsync();

            return response;
        }
    }
}
