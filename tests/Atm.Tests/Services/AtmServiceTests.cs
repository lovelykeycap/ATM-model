using Core.Items.Operations;
using Core.Services;
using Domain.Entities;
using Domain.Operations;
using Atm.Tests.Mocks;
using Xunit;

namespace Atm.Tests.Services;

public class AtmServiceTests
{
    [Fact]
    public void WithdrawWhenEnoughBalanceUpdatesAccountAndWritesHistory()
    {
        var sessionId = Guid.NewGuid();
        long accountId = 1;
        decimal initialBalance = 100m;
        decimal withdraw = 30m;

        var account = new PersonAccount(accountId, initialBalance);
        var session = new Session(sessionId, accountId);

        var history = new MockHistoryRepository();
        var personRepo = new MockPersonAccountRepository(account);
        var sessionRepo = new MockSessionRepository(session);
        var context = new MockPersistenceContext(history, personRepo, sessionRepo);
        var passwordProvider = new MockAdminPasswordProvider();

        var service = new AtmService(context, passwordProvider);

        WithDrawMoney.Response response = service.WithDrawMoney(new WithDrawMoney.Request(sessionId, withdraw));

        Assert.IsType<WithDrawMoney.Response.Success>(response);
        Assert.Equal(70m, account.Balance);
        Assert.True(personRepo.UpdateCalled);
        Assert.Single(history.Operations);

        Operation op = history.Operations[0];
        Assert.Equal(accountId, op.AccountId);
        Assert.Equal(OperationType.WithDraw, op.OperationType);
        Assert.Equal(withdraw, op.Value);
    }

    [Fact]
    public void WithdrawWhenNotEnoughBalanceReturnsFailureAndDoesNotUpdate()
    {
        var sessionId = Guid.NewGuid();
        long accountId = 1;
        decimal initialBalance = 10m;
        decimal withdraw = 20m;

        var account = new PersonAccount(accountId, initialBalance);
        var session = new Session(sessionId, accountId);

        var history = new MockHistoryRepository();
        var personRepo = new MockPersonAccountRepository(account);
        var sessionRepo = new MockSessionRepository(session);
        var context = new MockPersistenceContext(history, personRepo, sessionRepo);
        var passwordProvider = new MockAdminPasswordProvider();

        var service = new AtmService(context, passwordProvider);

        WithDrawMoney.Response response = service.WithDrawMoney(new WithDrawMoney.Request(sessionId, withdraw));

        Assert.IsType<WithDrawMoney.Response.Failure>(response);
        Assert.Equal(initialBalance, account.Balance);
        Assert.False(personRepo.UpdateCalled);
        Assert.Empty(history.Operations);
    }

    [Fact]
    public void DepositUpdatesAccountAndWritesHistory()
    {
        var sessionId = Guid.NewGuid();
        long accountId = 1;
        decimal initialBalance = 50m;
        decimal deposit = 20m;

        var account = new PersonAccount(accountId, initialBalance);
        var session = new Session(sessionId, accountId);

        var history = new MockHistoryRepository();
        var personRepo = new MockPersonAccountRepository(account);
        var sessionRepo = new MockSessionRepository(session);
        var context = new MockPersistenceContext(history, personRepo, sessionRepo);
        var passwordProvider = new MockAdminPasswordProvider();

        var service = new AtmService(context, passwordProvider);

        DepositMoney.Response response = service.DepositMoney(new DepositMoney.Request(sessionId, deposit));

        Assert.IsType<DepositMoney.Response.Success>(response);
        Assert.Equal(70m, account.Balance);
        Assert.True(personRepo.UpdateCalled);
        Assert.Single(history.Operations);

        Operation op = history.Operations[0];
        Assert.Equal(accountId, op.AccountId);
        Assert.Equal(OperationType.Deposit, op.OperationType);
        Assert.Equal(deposit, op.Value);
    }
}
