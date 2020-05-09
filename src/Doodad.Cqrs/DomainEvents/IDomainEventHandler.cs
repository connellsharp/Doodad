using System.Threading.Tasks;

namespace Doodad.Cqrs.Behaviors
{
    public interface IDomainEventHandler<TDomainEvent>
    {
        Task Handle(TDomainEvent domainEvent);
    }
}
