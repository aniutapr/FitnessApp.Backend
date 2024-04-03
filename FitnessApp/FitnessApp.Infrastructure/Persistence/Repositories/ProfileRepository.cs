using System;
using FitnessApp.Contracts.Interfaces.Repositories;
using FitnessApp.Domain.Entities;

namespace FitnessApp.Infrastructure.Persistence.Repositories;

public class ProfileRepository:IProfileRepository
{
	public ProfileRepository()
	{
	}

    public Task<UserProfile> AddProfileDataAsync(UserProfile profile)
    {
        throw new NotImplementedException();
    }

    public Task DeleteProfileDataAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<UserProfile> GetProfileByUserIdAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateProfileDataAsync(UserProfile profile)
    {
        throw new NotImplementedException();
    }
}