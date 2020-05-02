using System.Collections.Generic;

namespace Doodad
{
    public abstract class Entity
    {
        public ICollection<IDomainEvent> Events { get; }
    }
}
