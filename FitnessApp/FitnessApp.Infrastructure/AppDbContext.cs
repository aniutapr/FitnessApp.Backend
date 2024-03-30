using FitnessApp.Domain.Entities;
using FitnessApp.Infrastructure.Persistence.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Workout> Workouts { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<LogExcersise> LogExcersises { get; set; }
    public DbSet<Excersise> Excersises { get; set; }
    public DbSet<WorkoutGoal> WorkoutGoals { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new WorkoutConfiguration());
    }
}