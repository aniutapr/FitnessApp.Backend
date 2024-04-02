using FitnessApp.Domain.Entities;

namespace FitnessApp.Contracts.Interfaces.Repositories;

public interface IExcersiseLogRepository
{
    Task<IEnumerable<LogExcersise>> GetAllLogsByWorkoutIdAsync();  

    Task<LogExcersise> GetLogByLogIdAsync(Guid id);        

    Task LogExcersiseAsync(LogExcersise logExcersise);  

    Task UpdateLogAsync(LogExcersise logExcersise);     

    Task DeleteLogAsync(Guid id);                      
}