namespace Domain.Entities;

public interface IAccount
{
    long AccountId { get; }

    decimal Balance { get; }
}