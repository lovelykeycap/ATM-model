namespace Domain.Entities;

public class Session
{
    public Guid Id { get; }

    public long AccountID { get; }

    public Session(Guid id, long accountId)
    {
        Id = id;
        AccountID = accountId;
    }
}