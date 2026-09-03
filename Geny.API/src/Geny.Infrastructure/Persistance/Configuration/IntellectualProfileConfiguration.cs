using Geny.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Geny.Infrastructure.Persistance.Configuration;

public sealed class IntellectualProfileConfiguration : IEntityTypeConfiguration<IntellectualProfile>
{
    public void Configure(EntityTypeBuilder<IntellectualProfile> builder)
    {
        builder.ToTable("intellectual_profiles");

        builder.HasKey(ip => ip.UserId);

        builder.Property(ip => ip.CuriosityScore).IsRequired().HasDefaultValue(0);
        builder.Property(ip => ip.BreadthScore).IsRequired().HasDefaultValue(0);
        builder.Property(ip => ip.RetentionScore).IsRequired().HasDefaultValue(0);
        builder.Property(ip => ip.ProfileTitle).IsRequired().HasMaxLength(100);
        builder.Property(ip => ip.WeeklyInsight).IsRequired().HasMaxLength(1000);
        builder.Property(ip => ip.PreviousTitle).HasMaxLength(100);
        builder.Property(ip => ip.LastCalculatedAt).IsRequired();

        builder.Property(ip => ip.TopCategories)
            .HasColumnType("jsonb")
            .IsRequired();
    }
}
