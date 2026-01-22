namespace Core.Items.Models;

public readonly record struct OperationDto
{
    public long AccountId { get; }

    public string OperationType { get; }

    public decimal Value { get; }

    public OperationDto(long accountId, string operationType, decimal value)
    {
        AccountId = accountId;
        OperationType = operationType;
        Value = value;
    }
}
