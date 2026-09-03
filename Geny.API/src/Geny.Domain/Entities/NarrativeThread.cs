using Shared.Domain.Common;

namespace Geny.Domain.Entities;

public class NarrativeThread : Entity
{
    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public List<Guid> FactIds { get; private set; } = [];
    public Guid CategoryId { get; private set; }
    public Category? Category { get; private set; }
    public bool IsActive { get; private set; }
    public bool IsExclusive { get; private set; }

    public ICollection<UserNarrativeProgress> UserProgresses { get; private set; } = [];
    public ICollection<SocialFeedItem> SocialFeedItems { get; private set; } = [];

    private NarrativeThread() { } // for EF Core
}
