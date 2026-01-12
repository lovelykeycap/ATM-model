using Domain.Entities.Results;

namespace Domain.Entities;

public class PersonAccount : IAccount
{
    public long AccountId { get; }

    public decimal Balance { get; private set; }

    public PersonAccount(long accountId, decimal balance)
    {
        if (balance < 0)
        {
            throw new ArgumentException("Balance must be not negative");
        }

        AccountId = accountId;
        Balance = balance;
    }

    public ChangeBalanceResult WithDrawMoney(decimal value)
    {
        if (value > Balance)
        {
            return new ChangeBalanceResult.Failed("Not enough money");
        }

        Balance -= value;

        return new ChangeBalanceResult.Success();
    }

    public ChangeBalanceResult DepositMoney(decimal value)
    {
        Balance += value;

        return new ChangeBalanceResult.Success();
    }
}