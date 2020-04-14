using MediatR;

namespace Doodad.Cqrs
{
    public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, CommandResult>
        where TCommand : ICommand
    { }
}