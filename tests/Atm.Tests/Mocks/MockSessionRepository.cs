using Core.Abstractions.Persistence.Repositories;
using Domain.Entities;

namespace Atm.Tests.Mocks;

public class MockSessionRepository : ISessionRepository
{
    private readonly Session _session;

    public MockSessionRepository(Session session)
    {
        _session = session;
    }

    public Session Add(Session account)
    {
        return account;
    }

    public Session? GetByGuid(Guid id)
    {
        if (_session.Id == id)
            return _session;

        return null;
    }
}