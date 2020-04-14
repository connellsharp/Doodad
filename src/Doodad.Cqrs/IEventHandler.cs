using MediatR;

namespace Doodad.Cqrs
{
    public interface IEventHandler<TEvent> : INotificationHandler<TEvent>
        where TEvent : IEvent
    { }
}