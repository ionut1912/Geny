using Geny.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Geny.Infrastructure.Persistance.Configuration;

public sealed class UserReferralConfiguration : IEntityTypeConfiguration<UserReferral>
{
    public void Configure(EntityTypeBuilder<UserReferral> builder)
    {
        builder.ToTable("user_referrals");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id)
            .ValueGeneratedNever();

        builder.Property(r => r.ReferralToken).IsRequired().HasMaxLength(100);
        builder.Property(r => r.XpAwarded).IsRequired().HasDefaultValue(false);
        builder.Property(r => r.CreatedAt).IsRequired();

        builder.HasIndex(r => r.ReferralToken).IsUnique();
    }
}
