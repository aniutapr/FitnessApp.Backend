using System;
namespace FitnessApp.Contracts.Interfaces.Services
{
	public interface IPasswordHasher
	{
        public string Generate(string password);
        public bool Verify(string password, string hashedPassword);
    }
}

