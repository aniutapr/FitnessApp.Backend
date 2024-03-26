using System;
namespace FitnessApp.Contracts.Interfaces.Services
{
	public interface IUserService
	{
        public Task Register(string username, string email, string password);
        public Task<string> Login(string email, string password);
    }
}

