using inmind_DDD.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace inmind_DDD.Persistence;

public class AppDbContext : DbContext
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
            .HasMany(c => c.Students)
            .WithMany(s => s.Courses)
            .UsingEntity(j => j.ToTable("StudentCourses"));

        modelBuilder.Entity<Course>()
            .HasMany(c => c.Teachers)
            .WithMany(t => t.Courses)
            .UsingEntity(j => j.ToTable("TeacherCourses"));
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=UniDB;Username=postgres;Password=admin",
                b => b.MigrationsAssembly("Infrastructure.Persistence"));
        }
    }
}


