using System;
using FitnessApp.Domain.Entities;

namespace FitnessApp.Contracts.Interfaces.Repositories
{
	public interface IUserRepository
	{
		void AddUser(User user);
	}
}

