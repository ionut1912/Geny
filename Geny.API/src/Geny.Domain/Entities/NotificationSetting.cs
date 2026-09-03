using Shared.Domain.Common;

namespace Geny.Domain.Entities;

public class NotificationSetting : Entity
{
    public Guid UserId { get; private set; }
    public User? User { get; private set; }
    public bool DailyFactEnabled { get; private set; } = true;
    public TimeOnly DailyFactTime { get; private set; } = new TimeOnly(8, 0);
    public bool StreakReminderEnabled { get; private set; } = true;
    public bool LiveEventReminderEnabled { get; private set; } = true;
    public string? PushToken { get; private set; }

    private NotificationSetting() { } // for EF Core
}
