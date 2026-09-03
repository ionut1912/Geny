using Geny.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Geny.Infrastructure.Persistance.Configuration;

public sealed class NotificationSettingConfiguration : IEntityTypeConfiguration<NotificationSetting>
{
    public void Configure(EntityTypeBuilder<NotificationSetting> builder)
    {
        builder.ToTable("notification_settings");

        builder.HasKey(ns => ns.UserId);

        builder.Property(ns => ns.DailyFactEnabled).IsRequired().HasDefaultValue(true);
        builder.Property(ns => ns.DailyFactTime).IsRequired().HasDefaultValue(new TimeOnly(8, 0));
        builder.Property(ns => ns.StreakReminderEnabled).IsRequired().HasDefaultValue(true);
        builder.Property(ns => ns.LiveEventReminderEnabled).IsRequired().HasDefaultValue(true);
        builder.Property(ns => ns.PushToken).HasMaxLength(500);
        builder.Property(ns => ns.UpdatedAt).IsRequired();
    }
}
