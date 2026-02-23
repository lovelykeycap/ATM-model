using Core.Abstractions.Persistence.Repositories;
using Domain.Entities;

namespace Atm.Tests.Mocks;

public class MockPasswordRepository : IPasswordRepository
{
    public AccountPassword Add(AccountPassword password)
    {
        return password;
    }

    public AccountPassword? GetByAccountId(long accountId)
    {
        return null;
    }
}
