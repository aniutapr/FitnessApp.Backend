using System.Threading.Tasks;
using FitnessApp.Contracts.Interfaces.Repositories;
using FitnessApp.Domain.Entities;

namespace FitnessApp.Contracts.Interfaces.Services
{
    public interface IUserService
    {
        Task Register(string username, string email, string password, Role role);
        Task<string> Login(string email, string password);
    }
}