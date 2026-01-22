namespace Core.Items.Operations;

public class CreateAccount
{
    public readonly record struct Request(Guid AdminSessionId, string Password);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(long AccountId) : Response;

        public sealed record Failure(string Error) : Response;
    }
}