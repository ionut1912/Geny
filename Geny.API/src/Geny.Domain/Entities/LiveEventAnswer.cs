namespace Geny.Domain.Entities;

public class LiveEventAnswer
{
    public Guid LiveEventId { get; private set; }
    public LiveEvent? LiveEvent { get; private set; }
    public Guid UserId { get; private set; }
    public User? User { get; private set; }
    public Guid QuestionId { get; private set; }
    public QuizQuestion? Question { get; private set; }
    public string AnswerId { get; private set; } = string.Empty;
    public bool IsCorrect { get; private set; }
    public int AnsweredAtMs { get; private set; }
    public int PointsEarned { get; private set; }

    private LiveEventAnswer() { } // for EF Core
}
