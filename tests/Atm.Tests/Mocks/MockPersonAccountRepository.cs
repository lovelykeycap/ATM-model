using Core.Abstractions.Persistence.Repositories;
using Domain.Entities;

namespace Atm.Tests.Mocks;

public class MockPersonAccountRepository : IPersonAccountRepository
{
    private readonly PersonAccount _account;

    public MockPersonAccountRepository(PersonAccount account)
    {
        _account = account;
    }

    public bool UpdateCalled { get; private set; }

    public PersonAccount Add(PersonAccount account)
    {
        return account;
    }

    public PersonAccount? GetByAccountId(long id)
    {
        if (_account.AccountId == id)
            return _account;

        return null;
    }

    public void Update(PersonAccount account)
    {
        UpdateCalled = true;
    }
}
