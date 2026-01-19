using Domain.Entities;

namespace Core.Abstractions.Persistence.Repositories;

public interface IAdminSessionRepository
{
    AdminSession Add(AdminSession account);

    AdminSession? GetByGuid(Guid id);
}