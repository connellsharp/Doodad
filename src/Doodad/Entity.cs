using System;
using System.Collections.Generic;

namespace Doodad
{
    public abstract class Entity : IEntity
    {
        protected Entity(Guid id) => Id = id;

        public Guid Id { get; private set; }

        public ICollection<IDomainEvent> Events { get; } = new List<IDomainEvent>();
    }
}
