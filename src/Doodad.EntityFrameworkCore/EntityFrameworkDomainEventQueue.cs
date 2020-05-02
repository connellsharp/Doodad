using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Doodad.EntityFrameworkCore
{
    public class EntityFrameworkDomainEventQueue : IDomainEventQueue
    {
        private readonly DbContext _dbContext;

        public EntityFrameworkDomainEventQueue(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IReadOnlyCollection<IDomainEvent> DequeueDomainEvents()
        {
            return _dbContext.ChangeTracker.Entries<Entity>()
                .SelectMany(po => po.Entity.Events)
                .ToArray();
        }
    }
}
