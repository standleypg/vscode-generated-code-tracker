using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<MainUserStats> MainUserStats { get; set; }
    public DbSet<UserRecord> UserRecords { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectUser> ProjectUsers { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // MainUserStats
        modelBuilder.Entity<MainUserStats>().ToTable("MAIN_USER_STATS");
        modelBuilder.Entity<MainUserStats>()
            .HasKey(m => new { m.UserId, m.ProjectId, m.SolutionId });
        modelBuilder.Entity<MainUserStats>()
            .HasOne(m => m.User)
            .WithMany()
            .HasForeignKey(m => m.UserId);
        modelBuilder.Entity<MainUserStats>()
            .HasOne(m => m.Project)
            .WithMany()
            .HasForeignKey(m => m.ProjectId);

        // UserRecords
        modelBuilder.Entity<UserRecord>().ToTable("USER_RECORDS");
        modelBuilder.Entity<UserRecord>()
            .HasKey(u => new { u.UserId, u.SolutionId, u.SeqNo });
        modelBuilder.Entity<UserRecord>()
            .HasOne(u => u.User)
            .WithMany()
            .HasForeignKey(u => u.UserId);

        // Projects
        modelBuilder.Entity<Project>().ToTable("PROJECTS_LIST");
        modelBuilder.Entity<Project>()
            .HasKey(p => p.ProjectId);

        // ProjectUsers
        modelBuilder.Entity<ProjectUser>().ToTable("PROJECTS_USERS");
        modelBuilder.Entity<ProjectUser>()
            .HasKey(pu => new { pu.ProjectId, pu.UserId });
        modelBuilder.Entity<ProjectUser>()
            .HasOne(pu => pu.Project)
            .WithMany()
            .HasForeignKey(pu => pu.ProjectId);
        modelBuilder.Entity<ProjectUser>()
            .HasOne(pu => pu.User)
            .WithMany()
            .HasForeignKey(pu => pu.UserId);

        // Users
        modelBuilder.Entity<User>().ToTable("USERS");
        modelBuilder.Entity<User>()
            .HasKey(u => u.UserId);
    }
}
