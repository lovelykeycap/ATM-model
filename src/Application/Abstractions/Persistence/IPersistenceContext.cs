using Core.Abstractions.Persistence.Repositories;

namespace Core.Abstractions.Persistence;

public interface IPersistenceContext
{
    IHistoryRepository History { get; }

    IPasswordRepository Password { get; }

    IPersonAccountRepository Person { get; }

    ISessionRepository Session { get; }

    IAdminSessionRepository AdminSession { get; }
}