using System.Collections.Generic;

namespace Doodad
{
    public interface IDomainEventQueue
    {
        IReadOnlyCollection<IDomainEvent> DequeueDomainEvents();
    }
}
