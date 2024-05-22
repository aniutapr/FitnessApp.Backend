using FitnessApp.Contracts.Interfaces.Repositories;
using FitnessApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FitnessApp.Infrastructure.Repositories
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly AppDbContext _dbContext;

        public WorkoutRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Workout CloneWorkout(Workout workout)
        {
            return workout.Clone();
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
    public interface ILoggingWorkoutRepository
    {
        Workout CloneWorkout(Workout workout);
        Task<Workout> AddWorkoutAsync(Workout workout);
        Task DeleteWorkoutAsync(Guid id);
        Task<Workout> GetWorkoutByIdAsync(Guid id);
        Task<IEnumerable<Workout>> GetWorkoutsByUserIdAsync(Guid userId);
        Task<Workout> UpdateWorkoutAsync(Workout workout);

    }
  
        public class LoggingWorkoutRepository : ILoggingWorkoutRepository
        {
            private readonly IWorkoutRepository _repository;
            private readonly ILogger<LoggingWorkoutRepository> _logger;

            public LoggingWorkoutRepository(IWorkoutRepository repository, ILogger<LoggingWorkoutRepository> logger)
            {
                _repository = repository;
                _logger = logger;
            }

            public Workout CloneWorkout(Workout workout)
            {
                return _repository.CloneWorkout(workout);
            }

            public async Task<Workout> AddWorkoutAsync(Workout workout)
            {
                await LogInfoAsync($"Adding workout with ID {workout.WorkoutId}");
                var addedWorkout = await _repository.AddWorkoutAsync(workout);
                await LogInfoAsync($"Workout with ID {addedWorkout.WorkoutId} added successfully");
                return addedWorkout;
            }

            public async Task DeleteWorkoutAsync(Guid id)
            {
                await LogInfoAsync($"Deleting workout with ID {id}");
                await _repository.DeleteWorkoutAsync(id);
                await LogInfoAsync($"Workout with ID {id} deleted successfully");
            }

            public async Task<Workout> GetWorkoutByIdAsync(Guid id)
            {
                await LogInfoAsync($"Getting workout with ID {id}");
                var workout = await _repository.GetWorkoutByIdAsync(id);
                if (workout == null)
                {
                    await LogInfoAsync($"Workout with ID {id} not found");
                }
                else
                {
                    await LogInfoAsync($"Retrieved workout with ID {workout.WorkoutId}");
                }
                return workout;
            }

            public async Task<IEnumerable<Workout>> GetWorkoutsByUserIdAsync(Guid userId)
            {
                await LogInfoAsync($"Getting workouts for user with ID {userId}");
                var workouts = await _repository.GetWorkoutsByUserIdAsync(userId);
                await LogInfoAsync($"Retrieved {workouts.Count()} workouts for user with ID {userId}");
                return workouts;
            }

            public async Task<Workout> UpdateWorkoutAsync(Workout workout)
            {
                await LogInfoAsync($"Updating workout with ID {workout.WorkoutId}");
                var updatedWorkout = await _repository.UpdateWorkoutAsync(workout);
                await LogInfoAsync($"Workout with ID {updatedWorkout.WorkoutId} updated successfully");
                return updatedWorkout;
            }

            public async Task LogInfoAsync(string message)
            {
                _logger.LogInformation(message);
            }

            public async Task LogWarningAsync(string message)
            {
                _logger.LogWarning(message);
            }

            public async Task LogErrorAsync(string message, Exception ex)
            {
                _logger.LogError(ex, message);
            }
        }
    }
