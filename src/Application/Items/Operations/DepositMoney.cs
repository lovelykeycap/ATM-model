namespace Core.Items.Operations;

public class DepositMoney
{
    public readonly record struct Request(Guid Id, decimal Sum);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success : Response;

        public sealed record Failure(string Error) : Response;
    }
}