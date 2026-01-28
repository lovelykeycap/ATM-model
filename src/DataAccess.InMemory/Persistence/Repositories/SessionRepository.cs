using Core.Abstractions.Persistence.Repositories;
using Domain.Entities;

namespace DataAccess.InMemory.Persistence.Repositories;

public class SessionRepository : ISessionRepository
{
    private readonly Dictionary<Guid, Session> _sessions = new();

    public Session Add(Session account)
    {
        var session = new Session(Guid.NewGuid(), account.AccountID);
        _sessions[session.Id] = session;
        return session;
    }

    public Session? GetByGuid(Guid id)
    {
        if (_sessions.ContainsKey(id))
            return _sessions[id];

        return null;
    }
}
