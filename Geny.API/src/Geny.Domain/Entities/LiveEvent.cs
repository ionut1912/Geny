using Geny.Domain.ValueObjects;

using Shared.Domain.Common;

namespace Geny.Domain.Entities;

public class LiveEvent : Entity
{
    public string Title { get; private set; } = string.Empty;
    public DateTime ScheduledAt { get; private set; }
    public int DurationMinutes { get; private set; } = 10;
    public List<Guid> QuestionIds { get; private set; } = [];
    public LiveEventStatus Status { get; private set; } = LiveEventStatus.Scheduled;
    public int ParticipantCount { get; private set; }
    public Guid? WinnerId { get; private set; }
    public User? Winner { get; private set; }

    public ICollection<LiveEventParticipant> Participants { get; private set; } = [];
    public ICollection<LiveEventAnswer> Answers { get; private set; } = [];
    public ICollection<SocialFeedItem> SocialFeedItems { get; private set; } = [];

    private LiveEvent() { } // for EF Core
}
