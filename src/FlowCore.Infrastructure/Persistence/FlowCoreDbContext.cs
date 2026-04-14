using FlowCore.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlowCore.Infrastructure.Persistence;

/// <summary>
/// EF Core DbContext für FlowCore-Persistenz.
/// </summary>
public sealed class FlowCoreDbContext : DbContext
{
    public FlowCoreDbContext(DbContextOptions<FlowCoreDbContext> options)
        : base(options)
    {
    }

    public DbSet<WorkdayEntity> Workdays => Set<WorkdayEntity>();

    public DbSet<TimeEntryEntity> TimeEntries => Set<TimeEntryEntity>();

    public DbSet<ApprovalRequestEntity> ApprovalRequests => Set<ApprovalRequestEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WorkdayEntity>(entity =>
        {
            entity.ToTable("workdays");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.EmployeeId).IsRequired();
            entity.Property(x => x.Date).IsRequired();
            entity.HasIndex(x => new { x.EmployeeId, x.Date }).IsUnique();
            entity.HasMany(x => x.Entries)
                .WithOne(x => x.Workday)
                .HasForeignKey(x => x.WorkdayId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<TimeEntryEntity>(entity =>
        {
            entity.ToTable("time_entries");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.UserId).IsRequired();
            entity.Property(x => x.PresenceState).HasMaxLength(64).IsRequired();
            entity.Property(x => x.Timestamp).IsRequired();
            entity.Property(x => x.ProjectKey).HasMaxLength(128);
            entity.Property(x => x.Activity).HasMaxLength(256);
            entity.Property(x => x.Note).HasMaxLength(1000);
        });

        modelBuilder.Entity<ApprovalRequestEntity>(entity =>
        {
            entity.ToTable("approval_requests");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.EmployeeId).IsRequired();
            entity.Property(x => x.Reason).HasMaxLength(1000).IsRequired();
            entity.Property(x => x.RequestedAt).IsRequired();
        });
    }
}
