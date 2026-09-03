using Shared.Domain.Common;

namespace Geny.Domain.ValueObjects;

public class SocialFeedItemActionType : ValueObject
{
    public static readonly SocialFeedItemActionType ReadFact = new("ReadFact");
    public static readonly SocialFeedItemActionType CompletedThread = new("CompletedThread");
    public static readonly SocialFeedItemActionType JoinedLiveEvent = new("JoinedLiveEvent");
    public static readonly SocialFeedItemActionType ReactedDaily = new("ReactedDaily");
    public static readonly SocialFeedItemActionType SavedFact = new("SavedFact");
    private SocialFeedItemActionType(string value)
    {
        Value = value;
    }

    public string Value { get; }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public static SocialFeedItemActionType FromString(string value)
    {
        return value.Trim().ToLowerInvariant() switch
        {
            "readfact" => ReadFact,
            "completedthread" => CompletedThread,
            "joinedliveevent" => JoinedLiveEvent,
            "reacteddaily" => ReactedDaily,
            "savedfact" => SavedFact,
            _ => throw new ArgumentException($"Invalid social feed item action type: {value}")
        };
    }
}
