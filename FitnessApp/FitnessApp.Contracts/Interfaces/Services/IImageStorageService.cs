using Microsoft.AspNetCore.Http;

namespace FitnessApp.Contracts.Interfaces.Services
{
    public interface IImageStorageService
    {
        Task<string> SaveFileAsync(IFormFile file, string fileName);
    }
}