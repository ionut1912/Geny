using Shared.Domain.Common;

namespace Geny.Domain.Entities;

public class Collection : Entity
{
    public Guid UserId { get; private set; }
    public User? User { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string ShareToken { get; private set; } = string.Empty;

    public ICollection<CollectionFact> CollectionFacts { get; private set; } = [];

    private Collection() { } // for EF Core
}
