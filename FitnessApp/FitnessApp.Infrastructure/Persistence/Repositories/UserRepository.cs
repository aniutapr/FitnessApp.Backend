
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

        public void AddUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}

