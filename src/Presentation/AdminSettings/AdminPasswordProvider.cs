using Core.Abstractions.AdminSettings;

namespace Presentation.AdminSettings;

public class AdminPasswordProvider : IAdminPasswordProvider
{
    public string Password { get; }

    public AdminPasswordProvider(IConfiguration config)
    {
        Password = config["Admin:Password"]
                   ?? throw new InvalidOperationException("Admin password missing");
    }
}