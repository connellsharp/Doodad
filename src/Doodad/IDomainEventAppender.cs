namespace Doodad
{
    public interface IDomainEventAppender
    {
        void Add(IDomainEvent domainEvent);
    }
}
