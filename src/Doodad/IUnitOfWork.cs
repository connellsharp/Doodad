using System.Threading;
using System.Threading.Tasks;

namespace Doodad
{
    public interface IUnitOfWork
    {
        Task CommitAsync(CancellationToken cancellationToken);
    }
}
