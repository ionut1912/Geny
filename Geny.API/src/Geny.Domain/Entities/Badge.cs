using Geny.Domain.ValueObjects;

namespace Geny.Domain.Entities;

public class Badge
{
    public Guid UserId { get; private set; }
    public User? User { get; private set; }
    public BadgeType BadgeType { get; private set; } = BadgeType.StreakLegend;
    public DateTime EarnedAt { get; private set; }

    private Badge() { } // for EF Core
}
