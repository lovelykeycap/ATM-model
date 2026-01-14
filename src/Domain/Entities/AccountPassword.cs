namespace Domain.Entities;

public class AccountPassword
{
    public long AccountID { get; }

    public string Password { get; }

    public AccountPassword(long accountId, string password)
    {
        AccountID = accountId;
        Password = password;
    }
}