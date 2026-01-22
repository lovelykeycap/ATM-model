namespace Core.Items.Operations;

public static class ShowBalance
{
    public readonly record struct Request(Guid Id);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(decimal MoneyCount) : Response;

        public sealed record Failure(string Error) : Response;
    }
}