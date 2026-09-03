using Shared.Domain.Common;

namespace Geny.Domain.ValueObjects;

public class LiveEventStatus : ValueObject
{
    public static readonly LiveEventStatus Scheduled = new("Scheduled");
    public static readonly LiveEventStatus Live = new("Live");
    public static readonly LiveEventStatus Completed = new("Completed");
    private LiveEventStatus(string value)
    {
        Value = value;
    }

    public string Value { get; }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public static LiveEventStatus FromString(string value)
    {
        return value.Trim().ToLowerInvariant() switch
        {
            "scheduled" => Scheduled,
            "live" => Live,
            "completed" => Completed,
            _ => throw new ArgumentException($"Invalid live event status: {value}")
        };
    }
}
