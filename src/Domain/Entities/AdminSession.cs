namespace Domain.Entities;

public class AdminSession
{
    public Guid Id { get; }

    public AdminSession(Guid id)
    {
        Id = id;
    }
}