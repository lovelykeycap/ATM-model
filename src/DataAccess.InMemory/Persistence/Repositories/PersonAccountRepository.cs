using Core.Abstractions.Persistence.Repositories;
using Domain.Entities;

namespace DataAccess.InMemory.Persistence.Repositories;

public class PersonAccountRepository : IPersonAccountRepository
{
    private readonly Dictionary<long, PersonAccount> _accounts = new();
    private long _nextId = 1;

    public PersonAccount Add(PersonAccount account)
    {
        var created = new PersonAccount(_nextId++, account.Balance);
        _accounts[created.AccountId] = created;
        return created;
    }

    public PersonAccount? GetByAccountId(long id)
    {
        if (_accounts.ContainsKey(id))
            return _accounts[id];

        return null;
    }

    public void Update(PersonAccount account)
    {
        _accounts[account.AccountId] = account;
    }
}
