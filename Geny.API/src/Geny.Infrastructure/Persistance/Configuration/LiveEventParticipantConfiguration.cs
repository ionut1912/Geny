using Geny.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Geny.Infrastructure.Persistance.Configuration;

public sealed class LiveEventParticipantConfiguration : IEntityTypeConfiguration<LiveEventParticipant>
{
    public void Configure(EntityTypeBuilder<LiveEventParticipant> builder)
    {
        builder.ToTable("live_event_participants");

        builder.HasKey(lep => new { lep.LiveEventId, lep.UserId });

        builder.Property(lep => lep.JoinedAt).IsRequired();
        builder.Property(lep => lep.FinalScore).IsRequired().HasDefaultValue(0);
        builder.Property(lep => lep.FinalRank);
        builder.Property(lep => lep.XpAwarded).IsRequired().HasDefaultValue(0);
    }
}
