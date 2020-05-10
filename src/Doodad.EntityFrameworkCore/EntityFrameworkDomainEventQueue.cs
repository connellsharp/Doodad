using System.Collections.Generic;
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
            var domainEvents = new List<IDomainEvent>();

            foreach(var entry in _dbContext.ChangeTracker.Entries<IEntity>())
            {
                domainEvents.AddRange(entry.Entity.DomainEvents);
                entry.Entity.DomainEvents.Clear();
            }

            return domainEvents;
        }
    }
}
