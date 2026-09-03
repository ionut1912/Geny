using Shared.Domain.Common;

namespace Geny.Domain.Entities;

public class Fact : Entity
{
    public string HookSentence { get; private set; } = string.Empty;
    public string Level1 { get; private set; } = string.Empty;
    public string Level2 { get; private set; } = string.Empty;
    public string? Level3 { get; private set; }
    public Guid CategoryId { get; private set; }
    public Category? Category { get; private set; }
    public int Difficulty { get; private set; }
    public string? CalendarDate { get; private set; }
    public string? NarrativeHint { get; private set; }
    public string? SourceUrl { get; private set; }
    public bool IsPublished { get; private set; }

    public QuizQuestion? QuizQuestion { get; private set; }
    public ICollection<UserProgress> UserProgresses { get; private set; } = [];
    public ICollection<CollectionFact> CollectionFacts { get; private set; } = [];
    public ICollection<DailyEvent> DailyEvents { get; private set; } = [];
    public ICollection<SocialFeedItem> SocialFeedItems { get; private set; } = [];

    private Fact() { } // for EF Core
}
