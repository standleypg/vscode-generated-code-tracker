using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<SampleTable> SampleTables { get; set; }

    public DbSet<MainUserStat> MainUserStats { get; set; }

    public DbSet<ProjectsList> Projects { get; set; }

    public DbSet<UserRecord> UserRecords { get; set; }

    public DbSet<ProjectUser> ProjectUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MainUserStat>().ToTable("MAIN_USER_STATS");
        modelBuilder.Entity<MainUserStat>().HasKey(m => new { m.UserId, m.ProjectId, m.SolutionId });
        modelBuilder.Entity<MainUserStat>().Property(m => m.NoOfAutoGenLines).HasColumnType("numeric(18, 0)");

        modelBuilder.Entity<UserRecord>().ToTable("USER_RECORDS");
        modelBuilder.Entity<UserRecord>().HasKey(u => new { u.UserId, u.SolutionId, u.SeqNo });

        modelBuilder.Entity<ProjectsList>().ToTable("PROJECTS_LIST");

        modelBuilder.Entity<ProjectUser>().ToTable("PROJECTS_USERS");
        modelBuilder.Entity<ProjectUser>().HasKey(pu => new { pu.ProjectId, pu.UserId });

        base.OnModelCreating(modelBuilder);
    }
}
