using Geny.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Geny.Infrastructure.Persistance.Configuration;

public sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("categories");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .ValueGeneratedNever();

        builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
        builder.Property(c => c.Slug).IsRequired().HasMaxLength(100);
        builder.Property(c => c.IconUrl).IsRequired().HasMaxLength(500);
        builder.Property(c => c.Color).IsRequired().HasMaxLength(7);
        builder.Property(c => c.Description).HasMaxLength(500);
        builder.Property(c => c.IsActive).IsRequired();
        builder.Property(c => c.SortOrder).IsRequired();

        builder.HasIndex(c => c.Slug).IsUnique();
    }
}
