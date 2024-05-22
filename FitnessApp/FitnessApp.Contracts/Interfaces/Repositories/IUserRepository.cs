using FitnessApp.Domain.Entities;

namespace FitnessApp.Contracts.Interfaces.Repositories
{
    public interface IUserRepository
	{
		Task AddUser(User user);
        Task<User> GetByEmail(string email);
    }
}
//+