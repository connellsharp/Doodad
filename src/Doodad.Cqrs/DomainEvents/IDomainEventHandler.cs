using System.Threading.Tasks;

namespace Doodad.Cqrs.DomainEvents
{
    public interface IDomainEventHandler<TDomainEvent>
    {
        Task Handle(TDomainEvent domainEvent);
    }
}
