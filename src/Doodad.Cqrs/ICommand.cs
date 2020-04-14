using MediatR;

namespace Doodad.Cqrs
{
    public interface ICommand : IRequest<CommandResult>
    {
    }
}