using FitnessApp.Domain.Entities;

namespace FitnessApp.Contracts.Interfaces.Services
{
    public interface IUserService
    {
        Task Register(string username, string email, string password);
        Task<string> Login(string email, string password);
    }
}