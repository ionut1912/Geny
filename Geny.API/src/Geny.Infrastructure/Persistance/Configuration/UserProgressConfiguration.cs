using Geny.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Geny.Infrastructure.Persistance.Configuration;

public sealed class UserProgressConfiguration : IEntityTypeConfiguration<UserProgress>
{
    public void Configure(EntityTypeBuilder<UserProgress> builder)
    {
        builder.ToTable("user_progresses");

        builder.HasKey(up => new { up.UserId, up.FactId });

        builder.Property(up => up.SeenAt).IsRequired();
        builder.Property(up => up.DepthReached).IsRequired();
        builder.Property(up => up.TimeSpentSec).IsRequired().HasDefaultValue(0);
        builder.Property(up => up.QuizAnswered).IsRequired().HasDefaultValue(false);
        builder.Property(up => up.QuizCorrect);
        builder.Property(up => up.NextReviewAt);
    }
}
