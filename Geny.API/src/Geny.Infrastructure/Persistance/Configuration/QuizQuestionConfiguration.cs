using Geny.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Geny.Infrastructure.Persistance.Configuration;

public sealed class QuizQuestionConfiguration : IEntityTypeConfiguration<QuizQuestion>
{
    public void Configure(EntityTypeBuilder<QuizQuestion> builder)
    {
        builder.ToTable("quiz_questions");

        builder.HasKey(q => q.Id);

        builder.Property(q => q.Id)
            .ValueGeneratedNever();

        builder.Property(q => q.QuestionText).IsRequired();
        builder.Property(q => q.CorrectAnswer).IsRequired().HasMaxLength(500);
        builder.Property(q => q.XpReward).IsRequired().HasDefaultValue(25);

        builder.Property(q => q.WrongAnswers)
            .HasColumnType("jsonb")
            .IsRequired();

        builder.HasMany(q => q.LiveEventAnswers)
            .WithOne(lea => lea.Question)
            .HasForeignKey(lea => lea.QuestionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
