namespace Geny.Domain.Entities;

public class UserProgress
{
    public Guid UserId { get; private set; }
    public User? User { get; private set; }
    public Guid FactId { get; private set; }
    public Fact? Fact { get; private set; }
    public DateTime SeenAt { get; private set; }
    public int DepthReached { get; private set; }
    public int TimeSpentSec { get; private set; }
    public bool QuizAnswered { get; private set; }
    public bool? QuizCorrect { get; private set; }
    public DateTime? NextReviewAt { get; private set; }

    private UserProgress() { } // for EF Core
}
