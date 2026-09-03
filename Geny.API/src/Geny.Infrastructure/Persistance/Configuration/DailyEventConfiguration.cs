using Geny.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Geny.Infrastructure.Persistance.Configuration;

public sealed class DailyEventConfiguration : IEntityTypeConfiguration<DailyEvent>
{
    public void Configure(EntityTypeBuilder<DailyEvent> builder)
    {
        builder.ToTable("daily_events");

        builder.HasKey(de => de.Id);

        builder.Property(de => de.Id)
            .ValueGeneratedNever();

        builder.Property(de => de.EventDate).IsRequired();
        builder.Property(de => de.ContextText).IsRequired();
        builder.Property(de => de.TotalReactions).IsRequired().HasDefaultValue(0);
        builder.Property(de => de.PercentCorrectGuess).IsRequired().HasDefaultValue(0m).HasPrecision(5, 2);
        builder.Property(de => de.IsLive).IsRequired().HasDefaultValue(false);

        builder.HasIndex(de => de.EventDate).IsUnique();

        builder.HasMany(de => de.EventReactions)
            .WithOne(er => er.DailyEvent)
            .HasForeignKey(er => er.DailyEventId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
