using Shared.Domain.Common;

namespace Geny.Domain.Entities;

public class UserReferral : Entity
{
    public Guid InviterId { get; private set; }
    public User? Inviter { get; private set; }
    public Guid InviteeId { get; private set; }
    public User? Invitee { get; private set; }
    public string ReferralToken { get; private set; } = string.Empty;
    public DateTime? CompletedAt { get; private set; }
    public bool XpAwarded { get; private set; }

    private UserReferral() { } // for EF Core
}
