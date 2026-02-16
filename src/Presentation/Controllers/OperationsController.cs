using Core.Contracts;
using Core.Items.Models;
using Core.Items.Operations;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Presentation.Controllers;

[ApiController]
[Route("/api/operations")]
public class OperationsController : ControllerBase
{
    private readonly IAtmService _service;

    public OperationsController(IAtmService service)
    {
        _service = service;
    }

    [HttpPost("withdraw/{sessionId:guid}")]
    public IActionResult Withdraw([FromRoute] Guid sessionId, [FromQuery] decimal sum)
    {
        var request = new WithDrawMoney.Request(sessionId, sum);
        WithDrawMoney.Response response = _service.WithDrawMoney(request);

        return response switch
        {
            WithDrawMoney.Response.Success => Ok(),
            WithDrawMoney.Response.Failure failure => BadRequest(failure.Error),
            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("deposit/{sessionId:guid}")]
    public IActionResult Deposit([FromRoute] Guid sessionId, [FromQuery] decimal sum)
    {
        var request = new DepositMoney.Request(sessionId, sum);
        DepositMoney.Response response = _service.DepositMoney(request);

        return response switch
        {
            DepositMoney.Response.Success => Ok(),
            DepositMoney.Response.Failure failure => BadRequest(failure.Error),
            _ => throw new UnreachableException(),
        };
    }

    [HttpGet("balance/{sessionId:guid}")]
    public ActionResult<decimal> ShowBalance([FromRoute] Guid sessionId)
    {
        var request = new ShowBalance.Request(sessionId);
        ShowBalance.Response response = _service.ShowBalance(request);

        return response switch
        {
            ShowBalance.Response.Success success => Ok(success.MoneyCount),
            ShowBalance.Response.Failure failure => BadRequest(failure.Error),
            _ => throw new UnreachableException(),
        };
    }

    [HttpGet("history/{sessionId:guid}")]
    public ActionResult<IEnumerable<OperationDto>> ShowHistory([FromRoute] Guid sessionId)
    {
        var request = new ShowHistory.Request(sessionId);
        ShowHistory.Response response = _service.ShowOperationHistory(request);

        return response switch
        {
            ShowHistory.Response.Success success => Ok(success.Operations),
            ShowHistory.Response.Failure failure => BadRequest(failure.Error),
            _ => throw new UnreachableException(),
        };
    }
}
