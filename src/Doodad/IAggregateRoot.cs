using System.Collections.Generic;

namespace Doodad
{
    public interface IAggregateRoot
    {
        ICollection<IDomainEvent> Events { get; }
    }
}