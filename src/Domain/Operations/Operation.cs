namespace Domain.Operations;

public class Operation
{
    public long AccountId { get; }

    public OperationType OperationType { get; }

    public decimal Value { get; }

    public Operation(long accountId, OperationType operationType, decimal value)
    {
        AccountId = accountId;
        OperationType = operationType;
        Value = value;
    }
}