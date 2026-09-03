using Geny.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Geny.Infrastructure.Persistance.Configuration;

public sealed class CollectionFactConfiguration : IEntityTypeConfiguration<CollectionFact>
{
    public void Configure(EntityTypeBuilder<CollectionFact> builder)
    {
        builder.ToTable("collection_facts");

        builder.HasKey(cf => new { cf.CollectionId, cf.FactId });

        builder.Property(cf => cf.AddedAt).IsRequired();
    }
}
