using FitnessApp.Contracts.Interfaces.Repositories;
using FitnessApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Infrastructure.Persistence.Repositories;

public class ExcersiseRepository : IExcersiseRepository
{
    private readonly AppDbContext _dbContext;

    public ExcersiseRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Excersise>> GetAllExcersisesAsync()
    {
        return await _dbContext.Excersises.ToListAsync();
    }

    public async Task<Excersise> GetExcersiseByIdAsync(Guid id)
    {
        return await _dbContext.Excersises.FindAsync(id);
    }

    public async Task<Excersise> AddExcersiseAsync(Excersise excersise)
    {
        _dbContext.Excersises.Add(excersise);
        await _dbContext.SaveChangesAsync();
        return excersise;
    }

    public async Task<Excersise> UpdateExcersiseAsync(Excersise excersise)
    {
        var existingExcersise = await _dbContext.Excersises.FindAsync(excersise.Id);

        if (existingExcersise == null)
        {
            return null;
        }

        existingExcersise.Name = excersise.Name;
        existingExcersise.Description = excersise.Description;
        existingExcersise.Category = excersise.Category;
        existingExcersise.ImageUrlFile = excersise.ImageUrlFile;
        existingExcersise.VideoUrlFile = excersise.VideoUrlFile;
        existingExcersise.SuggestedRepeats = excersise.SuggestedRepeats;
        existingExcersise.SuggestedWeight = excersise.SuggestedWeight;

        _dbContext.Excersises.Update(existingExcersise);
        await _dbContext.SaveChangesAsync();

        return existingExcersise;
    }
    
    public async Task DeleteExcersiseAsync(Guid id)
    {
        var excersise = await _dbContext.Excersises.FindAsync(id);
        if (excersise != null)
        {
            _dbContext.Excersises.Remove(excersise);
            await _dbContext.SaveChangesAsync();
        }
    }
}