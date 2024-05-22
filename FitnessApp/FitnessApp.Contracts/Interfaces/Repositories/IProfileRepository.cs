using FitnessApp.Domain.Entities;

public interface IProfileRepository
{
    Task<UserProfile> GetProfileByUserIdAsync(Guid userId);
    Task<UserProfile> AddProfileDataAsync(UserProfile profile);
    Task UpdateProfileDataAsync(UserProfile profile);
    Task DeleteProfileDataAsync(Guid id);
}
//+