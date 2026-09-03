using Geny.Domain.Entities;
using Geny.Domain.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Geny.Infrastructure.Persistance.Configuration;

public sealed class SocialFeedItemConfiguration : IEntityTypeConfiguration<SocialFeedItem>
{
    public void Configure(EntityTypeBuilder<SocialFeedItem> builder)
    {
        builder.ToTable("social_feed_items");

        builder.HasKey(sf => sf.Id);

        builder.Property(sf => sf.Id)
            .ValueGeneratedNever();

        builder.Property(sf => sf.ActionType)
            .HasConversion(
                at => at.Value,
                value => SocialFeedItemActionType.FromString(value))
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("action_type");

        builder.Property(sf => sf.CreatedAt).IsRequired();
        builder.Property(sf => sf.FactId).IsRequired(false);
        builder.Property(sf => sf.ThreadId).IsRequired(false);
        builder.Property(sf => sf.LiveEventId).IsRequired(false);

        builder.HasIndex(sf => new { sf.UserId, sf.CreatedAt });
    }
}
