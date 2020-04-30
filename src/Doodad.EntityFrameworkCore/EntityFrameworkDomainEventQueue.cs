using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Doodad.EntityFrameworkCore
{
    public class EntityFrameworkDomainEventQueue : IDomainEventQueue
    {
        private readonly DbContext _dbContext;

        public EntityFrameworkUnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IReadOnlyCollection<IDomainEvent> DequeueDomainEvents()
        {
            
        }
    }
}
