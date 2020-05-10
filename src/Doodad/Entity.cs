using System;
using System.Collections.Generic;

namespace Doodad
{
    public abstract class Entity : IEntity
    {
        public Guid Id { get; protected set; } = Guid.NewGuid();

        public ICollection<IDomainEvent> DomainEvents { get; } = new List<IDomainEvent>();
    }
}
