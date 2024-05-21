using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public sealed class UserProjectConfiguration : IEntityTypeConfiguration<UserProject>
{
    public void Configure(EntityTypeBuilder<UserProject> builder)
    {
        builder.HasKey(up => new { up.Id, up.UserId, up.ProjectId });

        builder.Property(up => up.Id).HasColumnOrder(0);

        builder.Property(up => up.UserId).HasColumnOrder(1);
        
        builder.Property(up => up.ProjectId).HasColumnOrder(2);
        
        builder.HasOne(up => up.User)
            .WithMany(u => u.UserProjects)
            .HasForeignKey(up => new { up.UserId, up.UserEmail })
            .OnDelete(DeleteBehavior.Restrict);
            
        builder.HasOne(up => up.Project)
            .WithMany(p => p.UserProjects)
            .HasForeignKey(up => up.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
