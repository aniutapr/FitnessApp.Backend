using System;
using FitnessApp.Contracts.Interfaces.Repositories;
using FitnessApp.Domain.Entities;

namespace FitnessApp.Infrastructure.Persistence.Repositories;

public class ExcersiseLogRepository:IExcersiseLogRepository
{
    private readonly AppDbContext _context;
	public ExcersiseLogRepository(AppDbContext dbContext)
	{
        _context = dbContext;
	}

    public async Task DeleteLogAsync(Guid id)
    {
        var log = await _context.LogExcersises.FindAsync(id);
        _context.LogExcersises.Remove(log);
    }

    public Task<IEnumerable<LogExcersise>> GetAllLogsByWorkoutIdAsync()
    {
        throw new NotImplementedException();
    }

    public Task<LogExcersise> GetLogByLogIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task LogExcersiseAsync(LogExcersise logExcersise)
    {
        throw new NotImplementedException();
    }

    public Task UpdateLogAsync(LogExcersise logExcersise)
    {
        throw new NotImplementedException();
    }
}

