
using System;
using FitnessApp.Contracts.Interfaces.Repositories;
using FitnessApp.Domain.Entities;

namespace FitnessApp.Infrastructure.Persistence.Repositories
{
	public class UserRepository: IUserRepository
    {
		public UserRepository()
		{
		}

        public async Task AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByEmail(string email)
        {
            var userEntity = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email) ?? throw new Exception();
            return userEntity;
        }
    }
}

