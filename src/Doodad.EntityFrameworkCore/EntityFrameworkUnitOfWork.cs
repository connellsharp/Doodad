using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Doodad.EntityFrameworkCore
{
    public class EntityFrameworkUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;

        public EntityFrameworkUnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public Task CommitAsync(CancellationToken cancellationToken)
        {
            
        }
    }
}
