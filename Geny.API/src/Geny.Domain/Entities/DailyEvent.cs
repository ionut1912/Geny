using Shared.Domain.Common;

namespace Geny.Domain.Entities;

public class DailyEvent : Entity
{
    public Guid FactId { get; private set; }
    public Fact? Fact { get; private set; }
    public DateOnly EventDate { get; private set; }
    public string ContextText { get; private set; } = string.Empty;
    public int TotalReactions { get; private set; }
    public decimal PercentCorrectGuess { get; private set; }
    public bool IsLive { get; private set; }

    public ICollection<EventReaction> EventReactions { get; private set; } = [];

    private DailyEvent() { } // for EF Core
}
