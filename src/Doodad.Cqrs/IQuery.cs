using MediatR;

namespace Doodad.Cqrs
{
    public interface IQuery<TResult> : IRequest<TResult>
    {
    }
}