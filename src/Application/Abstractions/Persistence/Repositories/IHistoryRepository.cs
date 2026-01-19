using Domain.Operations;

namespace Core.Abstractions.Persistence.Repositories;

public interface IHistoryRepository
{
    Operation Add(Operation operation);

    IEnumerable<Operation> GetByUserId(long id);
}