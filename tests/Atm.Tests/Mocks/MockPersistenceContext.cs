using Core.Abstractions.Persistence;
using Core.Abstractions.Persistence.Repositories;

namespace Atm.Tests.Mocks;

public class MockPersistenceContext : IPersistenceContext
{
    public IHistoryRepository History { get; }

    public IPasswordRepository Password { get; }

    public IPersonAccountRepository Person { get; }

    public ISessionRepository Session { get; }

    public IAdminSessionRepository AdminSession { get; }

    public MockPersistenceContext(
        IHistoryRepository history,
        IPersonAccountRepository person,
        ISessionRepository session)
    {
        History = history;
        Person = person;
        Session = session;
        Password = new MockPasswordRepository();
        AdminSession = new MockAdminSessionRepository();
    }
}
