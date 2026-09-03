namespace Geny.Domain.Entities;

public class UserNarrativeProgress
{
    public Guid UserId { get; private set; }
    public User? User { get; private set; }
    public Guid NarrativeThreadId { get; private set; }
    public NarrativeThread? NarrativeThread { get; private set; }
    public int CurrentPosition { get; private set; }
    public DateTime StartedAt { get; private set; }
    public DateTime? CompletedAt { get; private set; }

    private UserNarrativeProgress() { } // for EF Core
}
