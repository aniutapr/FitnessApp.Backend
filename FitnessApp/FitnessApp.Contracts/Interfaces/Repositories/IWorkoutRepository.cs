using System;
using FitnessApp.Domain.Entities;

namespace FitnessApp.Contracts.Interfaces.Repositories;

public interface IWorkoutRepository
{
    Task<Workout> AddWorkoutAsync(Workout workout);

    Task<Workout> GetWorkoutByIdAsync(Guid id);
    Task<IEnumerable<Workout>> GetAllWorkoutsAsync();
    Task<IEnumerable<Workout>> GetWorkoutsByUserIdAsync(Guid userId);

    Task<Workout> UpdateWorkoutAsync(Workout workout);

    Task DeleteWorkoutAsync(Guid id);
}