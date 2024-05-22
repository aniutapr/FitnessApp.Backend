using FitnessApp.Domain.Entities;

namespace FitnessApp.Contracts.Interfaces.Repositories;

public interface IExcersiseRepository
{
    Task<IEnumerable<Excersise>> GetAllExcersisesAsync();
    Task<Excersise> GetExcersiseByIdAsync(Guid id);
    Task<Excersise> AddExcersiseAsync(Excersise excersise);
    Task<Excersise> UpdateExcersiseAsync(Excersise excersise);
    Task DeleteExcersiseAsync(Guid id);
}
//+