using Shared.Domain.Common;

namespace Geny.Domain.Entities;

public class QuizQuestion : Entity
{
    public Guid FactId { get; private set; }
    public Fact? Fact { get; private set; }
    public string QuestionText { get; private set; } = string.Empty;
    public string CorrectAnswer { get; private set; } = string.Empty;
    public List<string> WrongAnswers { get; private set; } = [];
    public int XpReward { get; private set; } = 25;

    public ICollection<LiveEventAnswer> LiveEventAnswers { get; private set; } = [];

    private QuizQuestion() { } // for EF Core
}
