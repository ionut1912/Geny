namespace Geny.Domain.Entities;

public class IntellectualProfile
{
    public Guid UserId { get; private set; }
    public User? User { get; private set; }
    public List<Guid> TopCategories { get; private set; } = [];
    public int CuriosityScore { get; private set; }
    public int BreadthScore { get; private set; }
    public int RetentionScore { get; private set; }
    public string ProfileTitle { get; private set; } = string.Empty;
    public string WeeklyInsight { get; private set; } = string.Empty;
    public string? PreviousTitle { get; private set; }
    public DateTime LastCalculatedAt { get; private set; }

    private IntellectualProfile() { } // for EF Core
}
