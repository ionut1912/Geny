using Geny.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Geny.Infrastructure.Persistance.Configuration;

public sealed class FactConfiguration : IEntityTypeConfiguration<Fact>
{
    public void Configure(EntityTypeBuilder<Fact> builder)
    {
        builder.ToTable("facts");

        builder.HasKey(f => f.Id);

        builder.Property(f => f.Id)
            .ValueGeneratedNever();

        builder.Property(f => f.HookSentence).IsRequired().HasMaxLength(200);
        builder.Property(f => f.Level1).IsRequired();
        builder.Property(f => f.Level2).IsRequired();
        builder.Property(f => f.Level3);
        builder.Property(f => f.Difficulty).IsRequired();
        builder.Property(f => f.CalendarDate).HasMaxLength(5);
        builder.Property(f => f.NarrativeHint).HasMaxLength(500);
        builder.Property(f => f.SourceUrl).HasMaxLength(1000);
        builder.Property(f => f.IsPublished).IsRequired().HasDefaultValue(false);
        builder.Property(f => f.CreatedAt).IsRequired();

        builder.HasOne(f => f.Category)
            .WithMany()
            .HasForeignKey(f => f.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(f => f.QuizQuestion)
            .WithOne(q => q.Fact)
            .HasForeignKey<QuizQuestion>(q => q.FactId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(f => f.UserProgresses)
            .WithOne(up => up.Fact)
            .HasForeignKey(up => up.FactId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(f => f.CollectionFacts)
            .WithOne(cf => cf.Fact)
            .HasForeignKey(cf => cf.FactId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(f => f.DailyEvents)
            .WithOne(de => de.Fact)
            .HasForeignKey(de => de.FactId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(f => f.SocialFeedItems)
            .WithOne(sf => sf.Fact)
            .HasForeignKey(sf => sf.FactId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasIndex(f => f.CalendarDate);
    }
}
