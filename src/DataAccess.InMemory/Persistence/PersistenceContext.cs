using Core.Abstractions.Persistence;
using Core.Abstractions.Persistence.Repositories;

namespace DataAccess.InMemory.Persistence;

public class PersistenceContext : IPersistenceContext
{
    public PersistenceContext(
        IHistoryRepository history,
        IPasswordRepository password,
        IPersonAccountRepository person,
        ISessionRepository session,
        IAdminSessionRepository adminSession)
    {
        History = history;
        Password = password;
        Person = person;
        Session = session;
        AdminSession = adminSession;
    }

    public IHistoryRepository History { get; }

    public IPasswordRepository Password { get; }

    public IPersonAccountRepository Person { get; }

    public ISessionRepository Session { get; }

    public IAdminSessionRepository AdminSession { get; }
}
