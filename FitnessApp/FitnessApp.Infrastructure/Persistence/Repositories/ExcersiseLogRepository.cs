using FitnessApp.Contracts.Interfaces.Repositories;
using FitnessApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Infrastructure.Persistence.Repositories
{
    public class ExcersiseLogRepository : IExcersiseLogRepository
    {
        private readonly AppDbContext _context;

        public ExcersiseLogRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task DeleteLogAsync(Guid id)
        {
            var log = await _context.LogExcersises.FindAsync(id);
            if (log != null)
            {
                _context.LogExcersises.Remove(log);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<LogExcersise>> GetAllLogsByWorkoutIdAsync(Guid workoutId)
        {
            return await _context.LogExcersises.Where(log => log.WorkoutId == workoutId).ToListAsync();
        }

        public async Task<LogExcersise> GetLogByLogIdAsync(Guid id)
        {
            return await _context.LogExcersises.FindAsync(id);
        }

        public async Task UpdateLogAsync(LogExcersise logExcersise)
        {
            _context.Entry(logExcersise).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<LogExcersise> LogExcersiseAsync(LogExcersise logExcersise)
        {
            var logExercise = new LogExerciseBuilder()
                .WithWorkoutId(logExcersise.WorkoutId)
                .WithExerciseId(logExcersise.ExcersiseId)
                .WithDuration(logExcersise.DurationInMin)
                .WithWeight(logExcersise.Weight)
                .WithRepeats(logExcersise.Repeats)
                .WithSets(logExcersise.Sets)
                .Build();

            _context.LogExcersises.Add(logExercise);
            await _context.SaveChangesAsync();

            return logExercise;
        }

    }
}
