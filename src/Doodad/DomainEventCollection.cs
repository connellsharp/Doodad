using System.Collections.Generic;

namespace Doodad
{
    internal class DomainEventCollection : List<IDomainEvent>, IDomainEventAppender
    {
    }
}