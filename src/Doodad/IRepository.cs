using System;

namespace Doodad
{
    public interface IRepository<T>
        where T : IAggregateRoot
    {
        T Get(Guid id);

        void Add(T aggregate);

        void Remove(T aggregate);
    }
}
