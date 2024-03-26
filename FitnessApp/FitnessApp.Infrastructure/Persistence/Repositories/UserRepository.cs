using FitnessApp.Contracts.Interfaces.Repositories;
using FitnessApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Infrastructure.Persistence.Repositories
{
    public class UserRepository: IUserRepository
    {
        private AppDbContext _context;

        public UserRepository(AppDbContext dbContext)
		{
            _context = dbContext;
		}

        public async Task AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByEmail(string email)
        {
            var userEntity = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);
            return userEntity;
        }
    }
}

