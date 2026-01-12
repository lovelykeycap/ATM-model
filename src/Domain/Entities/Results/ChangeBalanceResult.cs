namespace Domain.Entities.Results;

public abstract record ChangeBalanceResult
{
    private ChangeBalanceResult() { }

    public sealed record Success : ChangeBalanceResult;

    public sealed record Failed(string Error) : ChangeBalanceResult;
}