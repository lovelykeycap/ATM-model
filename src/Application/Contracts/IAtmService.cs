using Core.Items.Operations;

namespace Core.Contracts;

public interface IAtmService
{
    CreateSession.Response CreateUserSession(CreateSession.Request request);

    CreateSession.Response CreateAdminSession(CreateSession.Request request);

    ShowBalance.Response ShowBalance(ShowBalance.Request request);

    WithDrawMoney.Response WithDrawMoney(WithDrawMoney.Request request);

    DepositMoney.Response DepositMoney(DepositMoney.Request request);

    CreateAccount.Response CreateAccount(CreateAccount.Request request);

    ShowHistory.Response ShowOperationHistory(ShowHistory.Request request);
}