using System;

namespace Doodad
{
    public abstract class Entity : IEntity
    {
        public Guid Id { get; protected set; } = Guid.NewGuid();

        public IDomainEventAppender DomainEvents { get; } = new DomainEventCollection();
    }
}
