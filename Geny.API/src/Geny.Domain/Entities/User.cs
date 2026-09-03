using Shared.Domain.Common;

namespace Geny.Domain.Entities;

public class User : Entity
{
    public string Email { get; private set; } = string.Empty;
    public string Username { get; private set; } = string.Empty;
    public string? AvatarUrl { get; private set; }
    public bool IsPro { get; private set; }
    public DateTime? ProExpiresAt { get; private set; }
    public List<Guid> PreferredCategories { get; private set; } = [];
    public string DefaultMood { get; private set; } = "mixed";
    public int TotalXp { get; private set; }
    public bool IsProfilePublic { get; private set; }
    public DateTime LastLoginAt { get; private set; }

    public NotificationSetting? NotificationSetting { get; private set; }
    public IntellectualProfile? IntellectualProfile { get; private set; }

    public ICollection<UserProgress> UserProgresses { get; private set; } = [];
    public ICollection<Collection> Collections { get; private set; } = [];
    public ICollection<Badge> Badges { get; private set; } = [];
    public ICollection<EventReaction> EventReactions { get; private set; } = [];
    public ICollection<UserNarrativeProgress> NarrativeProgresses { get; private set; } = [];
    public ICollection<LiveEventParticipant> LiveEventParticipations { get; private set; } = [];
    public ICollection<LiveEventAnswer> LiveEventAnswers { get; private set; } = [];
    public ICollection<SocialFeedItem> SocialFeedItems { get; private set; } = [];
    public ICollection<UserReferral> SentReferrals { get; private set; } = [];
    public ICollection<UserReferral> ReceivedReferrals { get; private set; } = [];
    public ICollection<LiveEvent> WonLiveEvents { get; private set; } = [];

    private User() { } // for EF Core
}
