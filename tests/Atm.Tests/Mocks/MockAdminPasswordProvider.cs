using Core.Abstractions.AdminSettings;

namespace Atm.Tests.Mocks;

public class MockAdminPasswordProvider : IAdminPasswordProvider
{
    public string Password => "admin";
}
