using Core.Abstractions.AdminSettings;
using Core.Abstractions.Persistence;
using Core.Contracts;
using Core.Items.Models;
using Core.Items.Operations;
using Domain.Entities;
using Domain.Entities.Results;
using Domain.Operations;

namespace Core.Services;

public class AtmService : IAtmService
{
    private readonly IPersistenceContext _context;

    private readonly IAdminPasswordProvider _adminPasswordProvider;

    public AtmService(IPersistenceContext context, IAdminPasswordProvider passwordProvider)
    {
        _context = context;
        _adminPasswordProvider = passwordProvider;
    }

    public CreateSession.Response CreateUserSession(CreateSession.Request request)
    {
        if (request.AccountId is null)
            return new CreateSession.Response.Failure("AccountID must be not null");

        long accountId = request.AccountId.Value;
        PersonAccount? personAccount = _context.Person.GetByAccountId(accountId);

        if (personAccount is null)
            return new CreateSession.Response.Failure("Account not found");

        AccountPassword? password = _context.Password.GetByAccountId(accountId);
        if (password is null)
            return new CreateSession.Response.Failure("Password not found");

        if (password.Password != request.Password)
            return new CreateSession.Response.Failure("Wrong password");

        var session = new Session(Guid.Empty, personAccount.AccountId);
        session = _context.Session.Add(session);

        return new CreateSession.Response.Success(session.Id);
    }

    public CreateSession.Response CreateAdminSession(CreateSession.Request request)
    {
        if (request.Password != _adminPasswordProvider.Password)
            return new CreateSession.Response.Failure("Wrong admin password");

        var adminSession = new AdminSession(Guid.Empty);

        adminSession = _context.AdminSession.Add(adminSession);

        return new CreateSession.Response.Success(adminSession.Id);
    }

    public ShowBalance.Response ShowBalance(ShowBalance.Request request)
    {
        Session? session = _context.Session.GetByGuid(request.Id);

        if (session is null)
            return new ShowBalance.Response.Failure("Session not found");

        PersonAccount? account = _context.Person.GetByAccountId(session.AccountID);

        if (account is null)
            return new ShowBalance.Response.Failure("Account not found");

        return new ShowBalance.Response.Success(account.Balance);
    }

    public WithDrawMoney.Response WithDrawMoney(WithDrawMoney.Request request)
    {
        if (request.Sum <= 0)
            return new WithDrawMoney.Response.Failure("Amount must be positive");

        Session? session = _context.Session.GetByGuid(request.Id);
        if (session is null)
            return new WithDrawMoney.Response.Failure("Session not found");

        PersonAccount? account = _context.Person.GetByAccountId(session.AccountID);
        if (account is null)
            return new WithDrawMoney.Response.Failure("Account not found");

        ChangeBalanceResult result = account.WithDrawMoney(request.Sum);
        if (result is ChangeBalanceResult.Failed failed)
            return new WithDrawMoney.Response.Failure(failed.Error);

        _context.Person.Update(account);

        var operation = new Operation(account.AccountId, OperationType.WithDraw, request.Sum);
        _context.History.Add(operation);

        return new WithDrawMoney.Response.Success();
    }

    public DepositMoney.Response DepositMoney(DepositMoney.Request request)
    {
        if (request.Sum <= 0)
            return new DepositMoney.Response.Failure("Amount must be positive");

        Session? session = _context.Session.GetByGuid(request.Id);
        if (session is null)
            return new DepositMoney.Response.Failure("Session not found");

        PersonAccount? account = _context.Person.GetByAccountId(session.AccountID);
        if (account is null)
            return new DepositMoney.Response.Failure("Account not found");

        account.DepositMoney(request.Sum);

        _context.Person.Update(account);

        var operation = new Operation(account.AccountId, OperationType.Deposit, request.Sum);
        _context.History.Add(operation);

        return new DepositMoney.Response.Success();
    }

    public CreateAccount.Response CreateAccount(CreateAccount.Request request)
    {
        AdminSession? adminSession = _context.AdminSession.GetByGuid(request.AdminSessionId);
        if (adminSession is null)
            return new CreateAccount.Response.Failure("Admin session not found");

        var account = new PersonAccount(0, 0m);
        account = _context.Person.Add(account);

        var password = new AccountPassword(account.AccountId, request.Password);
        _context.Password.Add(password);

        return new CreateAccount.Response.Success(account.AccountId);
    }

    public ShowHistory.Response ShowOperationHistory(ShowHistory.Request request)
    {
        Session? session = _context.Session.GetByGuid(request.Id);
        if (session is null)
            return new ShowHistory.Response.Failure("Session not found");

        PersonAccount? account = _context.Person.GetByAccountId(session.AccountID);
        if (account is null)
            return new ShowHistory.Response.Failure("Account not found");

        IEnumerable<OperationDto> operations = _context.History.GetByUserId(account.AccountId)
            .Select(op => new OperationDto(op.AccountId, op.OperationType.ToString(), op.Value));

        return new ShowHistory.Response.Success(operations);
    }
}
