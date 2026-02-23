using Core.Abstractions.Persistence.Repositories;
using Domain.Entities;

namespace Atm.Tests.Mocks;

public class MockAdminSessionRepository : IAdminSessionRepository
{
    public AdminSession Add(AdminSession account)
    {
        return account;
    }

    public AdminSession? GetByGuid(Guid id)
    {
        return null;
    }
}