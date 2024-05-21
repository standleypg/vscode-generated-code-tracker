using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public sealed class StatConfiguration : IEntityTypeConfiguration<Stat>
{
    public void Configure(EntityTypeBuilder<Stat> builder)
    {
        builder.Property(s => s.NumberOfGeneratedLines)
            .HasColumnType("decimal(18,0)");

        builder.HasKey(s => s.Id);
        builder.HasOne(s => s.User)
            .WithMany(p => p.Stats)
            .HasForeignKey(s => new { s.UserId, s.UserEmail })
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(s => s.Project)
            .WithMany(p => p.Stats)
            .HasForeignKey(s => s.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);
            
        builder.HasOne(s => s.Solution)
            .WithMany(p => p.Stats)
            .HasForeignKey(s => s.SolutionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}