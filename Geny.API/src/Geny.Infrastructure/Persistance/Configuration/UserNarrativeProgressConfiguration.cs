using Geny.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Geny.Infrastructure.Persistance.Configuration;

public sealed class UserNarrativeProgressConfiguration : IEntityTypeConfiguration<UserNarrativeProgress>
{
    public void Configure(EntityTypeBuilder<UserNarrativeProgress> builder)
    {
        builder.ToTable("user_narrative_progresses");

        builder.HasKey(unp => new { unp.UserId, unp.NarrativeThreadId });

        builder.Property(unp => unp.CurrentPosition).IsRequired().HasDefaultValue(0);
        builder.Property(unp => unp.StartedAt).IsRequired();
        builder.Property(unp => unp.CompletedAt);
    }
}
