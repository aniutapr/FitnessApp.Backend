using System;
using FitnessApp.Domain.Entities;

namespace FitnessApp.Contracts.Interfaces.Repositories;

public interface IExcersiseRepository
{
    Task<IEnumerable<Excersise>> GetAllExcersisesAsync();
}