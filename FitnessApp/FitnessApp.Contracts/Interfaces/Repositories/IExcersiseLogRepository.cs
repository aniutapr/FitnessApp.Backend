using FitnessApp.Domain.Entities;

namespace FitnessApp.Contracts.Interfaces.Repositories;

public interface IExcersiseLogRepository
{
    Task<IEnumerable<LogExcersise>> GetAllLogsByWorkoutIdAsync(Guid workoutId);  

    Task<LogExcersise> GetLogByLogIdAsync(Guid id);        

    Task<LogExcersise> LogExcersiseAsync(LogExcersise logExcersise);  

    Task UpdateLogAsync(LogExcersise logExcersise);     

    Task DeleteLogAsync(Guid id);                      
}
//+