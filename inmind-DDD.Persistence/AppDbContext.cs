using inmind_DDD.Contracts.Interfaces;
using inmind_DDD.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace inmind_DDD.Persistence;

public class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<TimeSlot> TimeSlots { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Course>()
            .HasOne(c => c.Teacher)
            .WithMany(t => t.Courses)
            .HasForeignKey(c => c.TeacherId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Course>()
            .HasOne(c => c.TimeSlot)
            .WithOne(ts => ts.Course)
            .HasForeignKey<Course>(c => c.TimeSlotId)
            .OnDelete(DeleteBehavior.Restrict);
    }
    
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}



