using Core.Abstractions.Persistence.Repositories;
using Domain.Operations;

namespace DataAccess.InMemory.Persistence.Repositories;

public class HistoryRepository : IHistoryRepository
{
    private readonly List<Operation> _operations = new();

    public Operation Add(Operation operation)
    {
        _operations.Add(operation);
        return operation;
    }

    public IEnumerable<Operation> GetByUserId(long id)
    {
        return _operations.Where(x => x.AccountId == id).ToArray();
    }
}
