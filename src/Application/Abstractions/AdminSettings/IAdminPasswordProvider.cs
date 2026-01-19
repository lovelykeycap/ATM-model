namespace Core.Abstractions.AdminSettings;

public interface IAdminPasswordProvider
{
    string Password { get; }
}