using Core.Abstractions.Persistence.Repositories;
using Domain.Operations;

namespace Atm.Tests.Mocks;

public class MockHistoryRepository : IHistoryRepository
{
    private readonly List<Operation> _operations = new();

    public IReadOnlyList<Operation> Operations => _operations;

    public Operation Add(Operation operation)
    {
        _operations.Add(operation);
        return operation;
    }

    public IEnumerable<Operation> GetByUserId(long id)
    {
        return _operations.FindAll(x => x.AccountId == id);
    }
}