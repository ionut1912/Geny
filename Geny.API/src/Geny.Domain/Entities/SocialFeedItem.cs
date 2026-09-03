using Geny.Domain.ValueObjects;

using Shared.Domain.Common;

namespace Geny.Domain.Entities;

public class SocialFeedItem : Entity
{
    public Guid UserId { get; private set; }
    public User? User { get; private set; }
    public SocialFeedItemActionType ActionType { get; private set; } = SocialFeedItemActionType.ReadFact;
    public Guid? FactId { get; private set; }
    public Fact? Fact { get; private set; }
    public Guid? ThreadId { get; private set; }
    public NarrativeThread? NarrativeThread { get; private set; }
    public Guid? LiveEventId { get; private set; }
    public LiveEvent? LiveEvent { get; private set; }

    private SocialFeedItem() { } // for EF Core
}
