using Domain.Entities;

namespace Core.Abstractions.Persistence.Repositories;

public interface IPersonAccountRepository
{
    PersonAccount Add(PersonAccount account);

    PersonAccount? GetByAccountId(long id);

    void Update(PersonAccount account);
}