using System.Threading.Tasks;

namespace Doodad.Cqrs.Behaviors
{
    public interface IEventDispatcher
    {
        Task DispatchEventsAsync();
    }
}
