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

    public async Task<Workout> GetWorkoutByIdAsync(Guid id)
    {
        var workout= await _dbContext.Workouts.FirstOrDefaultAsync(w => w.WorkoutId == id);
        if(workout is null)
        {
            throw new Exception("Workout with this id was not found in database");
        }

        return workout;
    }

    public async Task<IEnumerable<Workout>> GetAllWorkoutsAsync()
    {
        return await _dbContext.Workouts.ToListAsync();
    }

    public async Task<IEnumerable<Workout>> GetWorkoutsByUserIdAsync(Guid userId)
    {
        return await _dbContext.Workouts.Where(w => w.UserId == userId).ToListAsync();
    }

    public async Task<Workout> UpdateWorkoutAsync(Workout workout)
    {
        var existingWorkout = await _dbContext.Workouts.FirstOrDefaultAsync(w => w.WorkoutId == workout.WorkoutId);
        if (existingWorkout is null)
        {
            throw new Exception("Workout with this id was not found in database");
        }
        existingWorkout = UpdateWorkout(existingWorkout, workout);
        await _dbContext.SaveChangesAsync();
        return existingWorkout;
    }

    private Workout UpdateWorkout(Workout existingWorkout, Workout workout)
    {
        existingWorkout.DateTime = workout.DateTime;
        existingWorkout.DurationInMin = workout.DurationInMin;
        existingWorkout.Excersises = workout.Excersises;
        existingWorkout.HowHard = workout.HowHard;
        existingWorkout.Stars = workout.Stars;
        return existingWorkout;
    }

    public async Task DeleteWorkoutAsync(Guid id)
    {
        var workout = await _dbContext.Workouts.FindAsync(id);
        if (workout != null)
        {
            _dbContext.Workouts.Remove(workout);
            await _dbContext.SaveChangesAsync();
        }
        throw new Exception("Workout with this id was not found in database");
    }
}