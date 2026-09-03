namespace Geny.Domain.Entities;

public class LiveEventParticipant
{
    public Guid LiveEventId { get; private set; }
    public LiveEvent? LiveEvent { get; private set; }
    public Guid UserId { get; private set; }
    public User? User { get; private set; }
    public DateTime JoinedAt { get; private set; }
    public int FinalScore { get; private set; }
    public int? FinalRank { get; private set; }
    public int XpAwarded { get; private set; }

    private LiveEventParticipant() { } // for EF Core
}
