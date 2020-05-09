using System.Threading.Tasks;

namespace Doodad.Cqrs.DomainEvents
{
    public interface IEventDispatcher
    {
        Task DispatchEventsAsync();
    }
}
