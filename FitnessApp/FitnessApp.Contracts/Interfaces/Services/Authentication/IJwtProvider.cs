using FitnessApp.Domain.Entities;

namespace FitnessApp.Contracts.Interfaces.Services;

public interface IJwtProvider
{
    string GenerateToken(User user);
}

