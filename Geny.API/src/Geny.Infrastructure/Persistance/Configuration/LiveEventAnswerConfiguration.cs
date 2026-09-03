using Geny.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Geny.Infrastructure.Persistance.Configuration;

public sealed class LiveEventAnswerConfiguration : IEntityTypeConfiguration<LiveEventAnswer>
{
    public void Configure(EntityTypeBuilder<LiveEventAnswer> builder)
    {
        builder.ToTable("live_event_answers");

        builder.HasKey(lea => new { lea.LiveEventId, lea.UserId, lea.QuestionId });

        builder.Property(lea => lea.AnswerId).IsRequired().HasMaxLength(50);
        builder.Property(lea => lea.IsCorrect).IsRequired();
        builder.Property(lea => lea.AnsweredAtMs).IsRequired();
        builder.Property(lea => lea.PointsEarned).IsRequired().HasDefaultValue(0);
    }
}
