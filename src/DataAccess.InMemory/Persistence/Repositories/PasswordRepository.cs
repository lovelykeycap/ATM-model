using Core.Abstractions.Persistence.Repositories;
using Domain.Entities;

namespace DataAccess.InMemory.Persistence.Repositories;

public class PasswordRepository : IPasswordRepository
{
    private readonly Dictionary<long, AccountPassword> _passwords = new();

    public AccountPassword Add(AccountPassword password)
    {
        _passwords[password.AccountID] = password;
        return password;
    }

    public AccountPassword? GetByAccountId(long accountId)
    {
        if (_passwords.ContainsKey(accountId))
            return _passwords[accountId];

        return null;
    }
}
