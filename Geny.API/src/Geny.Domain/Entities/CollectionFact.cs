namespace Geny.Domain.Entities;

public class CollectionFact
{
    public Guid CollectionId { get; private set; }
    public Collection? Collection { get; private set; }
    public Guid FactId { get; private set; }
    public Fact? Fact { get; private set; }
    public DateTime AddedAt { get; private set; }

    private CollectionFact() { } // for EF Core
}
