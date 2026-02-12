using Core.Contracts;
using Core.Items.Operations;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Presentation.Controllers;

[ApiController]
[Route("/api/createSession")]
public class SessionController : ControllerBase
{
    private readonly IAtmService _service;

    public SessionController(IAtmService service)
    {
        _service = service;
    }

    [HttpPost("user")]
    public ActionResult<Guid> CreateUserSession(long accountId, string password)
    {
        var request = new CreateSession.Request(accountId, password);
        CreateSession.Response response = _service.CreateUserSession(request);

        return response switch
        {
            CreateSession.Response.Success success => Ok(success.SessionId),
            CreateSession.Response.Failure failure => BadRequest(failure.Error),
            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("admin")]
    public ActionResult<Guid> CreateAdminSession(string password)
    {
        var request = new CreateSession.Request(null, password);
        CreateSession.Response response = _service.CreateAdminSession(request);

        return response switch
        {
            CreateSession.Response.Success success => Ok(success.SessionId),
            CreateSession.Response.Failure failure => BadRequest(failure.Error),
            _ => throw new UnreachableException(),
        };
    }
}
