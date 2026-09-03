using Geny.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Geny.Infrastructure.Persistance.Configuration;

public sealed class CollectionConfiguration : IEntityTypeConfiguration<Collection>
{
    public void Configure(EntityTypeBuilder<Collection> builder)
    {
        builder.ToTable("collections");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .ValueGeneratedNever();

        builder.Property(c => c.Name).IsRequired().HasMaxLength(200);
        builder.Property(c => c.ShareToken).IsRequired().HasMaxLength(100);
        builder.Property(c => c.CreatedAt).IsRequired();

        builder.HasIndex(c => c.ShareToken).IsUnique();

        builder.HasMany(c => c.CollectionFacts)
            .WithOne(cf => cf.Collection)
            .HasForeignKey(cf => cf.CollectionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
