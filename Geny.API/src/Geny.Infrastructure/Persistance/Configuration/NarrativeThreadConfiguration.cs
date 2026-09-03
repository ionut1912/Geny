using Geny.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Geny.Infrastructure.Persistance.Configuration;

public sealed class NarrativeThreadConfiguration : IEntityTypeConfiguration<NarrativeThread>
{
    public void Configure(EntityTypeBuilder<NarrativeThread> builder)
    {
        builder.ToTable("narrative_threads");

        builder.HasKey(nt => nt.Id);

        builder.Property(nt => nt.Id)
            .ValueGeneratedNever();

        builder.Property(nt => nt.Title).IsRequired().HasMaxLength(300);
        builder.Property(nt => nt.Description).IsRequired();
        builder.Property(nt => nt.IsActive).IsRequired();
        builder.Property(nt => nt.IsExclusive).IsRequired();

        builder.Property(nt => nt.FactIds)
            .HasColumnType("jsonb")
            .IsRequired();

        builder.HasOne(nt => nt.Category)
            .WithMany()
            .HasForeignKey(nt => nt.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(nt => nt.UserProgresses)
            .WithOne(unp => unp.NarrativeThread)
            .HasForeignKey(unp => unp.NarrativeThreadId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(nt => nt.SocialFeedItems)
            .WithOne(sf => sf.NarrativeThread)
            .HasForeignKey(sf => sf.ThreadId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
