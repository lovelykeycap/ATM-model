using Domain.Entities;

namespace Core.Abstractions.Persistence.Repositories;

public interface IPasswordRepository
{
    AccountPassword Add(AccountPassword password);

    AccountPassword? GetByAccountId(long accountId);
}