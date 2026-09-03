using Geny.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Geny.Infrastructure.Persistance.Configuration;

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .ValueGeneratedNever();

        builder.Property(u => u.Email).IsRequired().HasMaxLength(256);
        builder.Property(u => u.Username).IsRequired().HasMaxLength(100);
        builder.Property(u => u.AvatarUrl).HasMaxLength(1000);
        builder.Property(u => u.IsPro).IsRequired();
        builder.Property(u => u.DefaultMood).IsRequired().HasMaxLength(20).HasDefaultValue("mixed");
        builder.Property(u => u.TotalXp).IsRequired().HasDefaultValue(0);
        builder.Property(u => u.IsProfilePublic).IsRequired().HasDefaultValue(false);
        builder.Property(u => u.CreatedAt).IsRequired();
        builder.Property(u => u.LastLoginAt).IsRequired();

        builder.Property(u => u.PreferredCategories)
            .HasColumnType("jsonb")
            .IsRequired();

        builder.HasIndex(u => u.Email).IsUnique();

        builder.HasOne(u => u.NotificationSetting)
            .WithOne(ns => ns.User)
            .HasForeignKey<NotificationSetting>(ns => ns.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(u => u.IntellectualProfile)
            .WithOne(ip => ip.User)
            .HasForeignKey<IntellectualProfile>(ip => ip.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.UserProgresses)
            .WithOne(up => up.User)
            .HasForeignKey(up => up.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.Collections)
            .WithOne(c => c.User)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.Badges)
            .WithOne(b => b.User)
            .HasForeignKey(b => b.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.EventReactions)
            .WithOne(er => er.User)
            .HasForeignKey(er => er.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.NarrativeProgresses)
            .WithOne(np => np.User)
            .HasForeignKey(np => np.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.LiveEventParticipations)
            .WithOne(lep => lep.User)
            .HasForeignKey(lep => lep.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.LiveEventAnswers)
            .WithOne(lea => lea.User)
            .HasForeignKey(lea => lea.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.SocialFeedItems)
            .WithOne(sf => sf.User)
            .HasForeignKey(sf => sf.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.SentReferrals)
            .WithOne(r => r.Inviter)
            .HasForeignKey(r => r.InviterId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(u => u.ReceivedReferrals)
            .WithOne(r => r.Invitee)
            .HasForeignKey(r => r.InviteeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(u => u.WonLiveEvents)
            .WithOne(le => le.Winner)
            .HasForeignKey(le => le.WinnerId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
