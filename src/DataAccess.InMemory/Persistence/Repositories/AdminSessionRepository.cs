using Core.Abstractions.Persistence.Repositories;
using Domain.Entities;

namespace DataAccess.InMemory.Persistence.Repositories;

public class AdminSessionRepository : IAdminSessionRepository
{
    private readonly Dictionary<Guid, AdminSession> _sessions = new();

    public AdminSession Add(AdminSession account)
    {
        var session = new AdminSession(Guid.NewGuid());
        _sessions[session.Id] = session;
        return session;
    }

    public AdminSession? GetByGuid(Guid id)
    {
        if (_sessions.ContainsKey(id))
            return _sessions[id];

        return null;
    }
}
