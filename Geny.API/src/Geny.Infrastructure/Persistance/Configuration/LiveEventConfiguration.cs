using Geny.Domain.Entities;
using Geny.Domain.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Geny.Infrastructure.Persistance.Configuration;

public sealed class LiveEventConfiguration : IEntityTypeConfiguration<LiveEvent>
{
    public void Configure(EntityTypeBuilder<LiveEvent> builder)
    {
        builder.ToTable("live_events");

        builder.HasKey(le => le.Id);

        builder.Property(le => le.Id)
            .ValueGeneratedNever();

        builder.Property(le => le.Title).IsRequired().HasMaxLength(300);
        builder.Property(le => le.ScheduledAt).IsRequired();
        builder.Property(le => le.DurationMinutes).IsRequired().HasDefaultValue(10);
        builder.Property(le => le.ParticipantCount).IsRequired().HasDefaultValue(0);
        builder.Property(le => le.WinnerId).IsRequired(false);

        builder.Property(le => le.Status)
            .HasConversion(
                s => s.Value,
                value => LiveEventStatus.FromString(value))
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("status");

        builder.Property(le => le.QuestionIds)
            .HasColumnType("jsonb")
            .IsRequired();

        builder.HasMany(le => le.Participants)
            .WithOne(lep => lep.LiveEvent)
            .HasForeignKey(lep => lep.LiveEventId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(le => le.Answers)
            .WithOne(lea => lea.LiveEvent)
            .HasForeignKey(lea => lea.LiveEventId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(le => le.SocialFeedItems)
            .WithOne(sf => sf.LiveEvent)
            .HasForeignKey(sf => sf.LiveEventId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
