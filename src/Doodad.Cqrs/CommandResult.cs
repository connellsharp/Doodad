namespace Doodad.Cqrs
{
    public class CommandResult
    {
        public CommandResult(bool isSuccess, string message = null)
            => (IsSuccess, Message) = (isSuccess, message);

        public bool IsSuccess { get; }

        public string Message { get; }
    }
}