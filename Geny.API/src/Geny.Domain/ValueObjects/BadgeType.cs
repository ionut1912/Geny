using Shared.Domain.Common;

namespace Geny.Domain.ValueObjects;

public class BadgeType : ValueObject
{
    public static readonly BadgeType ExplorerCosmic = new("ExplorerCosmic");
    public static readonly BadgeType StreakLegend = new("StreakLegend");
    public static readonly BadgeType ThreadMaster = new("ThreadMaster");
    public static readonly BadgeType LiveChampion = new("LiveChampion");

    private BadgeType(string value)
    {
        Value = value;
    }
    public string Value { get; }
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public static BadgeType FromString(string value)
    {
        return value.Trim().ToLowerInvariant() switch
        {
            "ExplorerCosmic" => ExplorerCosmic,
            "StreakLegend" => StreakLegend,
            "ThreadMaster" => ThreadMaster,
            "LiveChampion" => LiveChampion,
            _ => throw new ArgumentException($"Invalid badge type: {value}")
        };
    }
}
