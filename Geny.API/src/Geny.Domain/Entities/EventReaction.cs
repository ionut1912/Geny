using Geny.Domain.ValueObjects;

namespace Geny.Domain.Entities;

public class EventReaction
{
    public Guid UserId { get; private set; }
    public User? User { get; private set; }
    public Guid DailyEventId { get; private set; }
    public DailyEvent? DailyEvent { get; private set; }
    public bool? GuessedBeforeReveal { get; private set; }
    public ReactionType ReactionType { get; private set; } = ReactionType.DidntKnow;
    public DateTime ReactedAt { get; private set; }
    public bool SharedToday { get; private set; }

    private EventReaction() { } // for EF Core
}
