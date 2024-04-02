using FitnessApp.Contracts.Interfaces.Repositories;
using FitnessApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Infrastructure.Persistence.Repositories
{
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
    }
}