using Geny.Domain.Entities;
using Geny.Domain.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Geny.Infrastructure.Persistance.Configuration;

public sealed class BadgeConfiguration : IEntityTypeConfiguration<Badge>
{
    public void Configure(EntityTypeBuilder<Badge> builder)
    {
        builder.ToTable("badges");

        builder.HasKey(b => new { b.UserId, b.BadgeType });

        builder.Property(b => b.BadgeType)
            .HasConversion(
                bt => bt.Value,
                value => BadgeType.FromString(value))
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("badge_type");

        builder.Property(b => b.EarnedAt).IsRequired();
    }
}
