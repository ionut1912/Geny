using Shared.Domain.Common;

namespace Geny.Domain.ValueObjects;

public class ReactionType : ValueObject
{
    public static readonly ReactionType Wow = new("Wow");
    public static readonly ReactionType DidntKnow = new("DidntKnow");
    public static readonly ReactionType HardToBelieve = new("HardToBelieve");
    public static readonly ReactionType WantMore = new("WantMore");

    private ReactionType(string value)
    {
        Value = value;
    }

    public string Value { get; }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public static ReactionType FromString(string value)
    {
        return value.Trim().ToLowerInvariant() switch
        {
            "wow" => Wow,
            "didntknow" => DidntKnow,
            "hardtobelieve" => HardToBelieve,
            "wantmore" => WantMore,
            _ => throw new ArgumentException($"Invalid reaction type: {value}")
        };
    }
}
