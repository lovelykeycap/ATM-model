using Core.Items.Models;

namespace Core.Items.Operations;

public class ShowHistory
{
    public readonly record struct Request(Guid Id);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(IEnumerable<OperationDto> Operations) : Response;

        public sealed record Failure(string Error) : Response;
    }
}