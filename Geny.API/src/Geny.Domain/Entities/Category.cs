using Shared.Domain.Common;

namespace Geny.Domain.Entities;

public class Category : Entity
{
    public string Name { get; private set; } = string.Empty;
    public string Slug { get; private set; } = string.Empty;
    public string IconUrl { get; private set; } = string.Empty;
    public string Color { get; private set; } = string.Empty;
    public string? Description { get; private set; }
    public bool IsActive { get; private set; }
    public int SortOrder { get; private set; }

    private Category() { } // for EF Core
}
