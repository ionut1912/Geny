using Geny.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace Geny.Infrastructure.Persistance;

public class GenyDbContext : DbContext
{
    public GenyDbContext(DbContextOptions<GenyDbContext> options) : base(options) { }

    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Fact> Facts => Set<Fact>();
    public DbSet<QuizQuestion> QuizQuestions => Set<QuizQuestion>();
    public DbSet<User> Users => Set<User>();
    public DbSet<NotificationSetting> NotificationSettings => Set<NotificationSetting>();
    public DbSet<IntellectualProfile> IntellectualProfiles => Set<IntellectualProfile>();
    public DbSet<Badge> Badges => Set<Badge>();
    public DbSet<UserProgress> UserProgresses => Set<UserProgress>();
    public DbSet<UserReferral> UserReferrals => Set<UserReferral>();
    public DbSet<Collection> Collections => Set<Collection>();
    public DbSet<CollectionFact> CollectionFacts => Set<CollectionFact>();
    public DbSet<DailyEvent> DailyEvents => Set<DailyEvent>();
    public DbSet<EventReaction> EventReactions => Set<EventReaction>();
    public DbSet<NarrativeThread> NarrativeThreads => Set<NarrativeThread>();
    public DbSet<UserNarrativeProgress> UserNarrativeProgresses => Set<UserNarrativeProgress>();
    public DbSet<LiveEvent> LiveEvents => Set<LiveEvent>();
    public DbSet<LiveEventParticipant> LiveEventParticipants => Set<LiveEventParticipant>();
    public DbSet<LiveEventAnswer> LiveEventAnswers => Set<LiveEventAnswer>();
    public DbSet<SocialFeedItem> SocialFeedItems => Set<SocialFeedItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GenyDbContext).Assembly);
    }
}
