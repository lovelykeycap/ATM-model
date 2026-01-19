using Domain.Entities;

namespace Core.Abstractions.Persistence.Repositories;

public interface ISessionRepository
{
    Session Add(Session account);

    Session? GetByGuid(Guid id);
}