using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => new { u.Id, u.UserEmail });

        builder.Property(u => u.UserEmail).HasMaxLength(50).HasColumnOrder(1);
        
        builder.Property(u => u.UserName).HasMaxLength(50);
    }
}