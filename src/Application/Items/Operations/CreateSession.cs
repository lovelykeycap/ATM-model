namespace Core.Items.Operations;

public static class CreateSession
{
    public readonly record struct Request(long? AccountId, string Password);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(Guid SessionId) : Response;

        public sealed record Failure(string Error) : Response;
    }
}