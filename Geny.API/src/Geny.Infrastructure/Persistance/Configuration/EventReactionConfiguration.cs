using Geny.Domain.Entities;
using Geny.Domain.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Geny.Infrastructure.Persistance.Configuration;

public sealed class EventReactionConfiguration : IEntityTypeConfiguration<EventReaction>
{
    public void Configure(EntityTypeBuilder<EventReaction> builder)
    {
        builder.ToTable("event_reactions");

        builder.HasKey(er => new { er.UserId, er.DailyEventId });

        builder.Property(er => er.ReactionType)
            .HasConversion(
                rt => rt.Value,
                value => ReactionType.FromString(value))
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("reaction_type");

        builder.Property(er => er.ReactedAt).IsRequired();
        builder.Property(er => er.SharedToday).IsRequired().HasDefaultValue(false);
    }
}
