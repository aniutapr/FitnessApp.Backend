using FitnessApp.Contracts.Interfaces.Repositories;
using FitnessApp.Domain.Entities;
using FitnessApp.Infrastructure;
using Microsoft.EntityFrameworkCore;

public class WorkoutRepository : IWorkoutRepository
{
    private readonly AppDbContext _dbContext;

    public WorkoutRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Workout> AddWorkoutAsync(Workout workout)
    {
        _dbContext.Workouts.Add(workout);
        await _dbContext.SaveChangesAsync();
        return workout;
    }

    public async Task DeleteWorkoutAsync(Guid id)
    {
        var workout = await _dbContext.Workouts.FindAsync(id);
        if (workout != null)
        {
            _dbContext.Workouts.Remove(workout);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<Workout> GetWorkoutByIdAsync(Guid id)
    {
        return await _dbContext.Workouts.FindAsync(id);
    }

    public async Task<IEnumerable<Workout>> GetWorkoutsByUserIdAsync(Guid userId)
    {
        return await _dbContext.Workouts
            .Where(w => w.UserId == userId)
            .ToListAsync();
    }

    public async Task<Workout> UpdateWorkoutAsync(Workout workout)
    {
        _dbContext.Entry(workout).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return workout;
    }
}
