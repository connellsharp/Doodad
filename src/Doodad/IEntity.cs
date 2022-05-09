using System;
using System.Collections.Generic;

namespace Doodad
{
    public interface IEntity
    {
        Guid Id { get; }
        
        IDomainEventAppender DomainEvents { get; }
    }
}
