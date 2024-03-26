using FitnessApp.Contracts.Interfaces.Repositories;
using FitnessApp.Contracts.Interfaces.Services;
using FitnessApp.Domain.Entities;

namespace FitnessApp.Application.Services;

public class UserService:IUserService
{
	private readonly IPasswordHasher _passwordHasher;
    private IUserRepository _userRepository;

    public UserService(IPasswordHasher hasher)
	{
		_passwordHasher = hasher;
	}
	public async Task Register(string username, string email, string password)
	{
		var hashedPassword = _passwordHasher.Generate(password);
		var user = User.Create(Guid.NewGuid(), username, hashedPassword, email);
		await _userRepository.AddUser(user);

	}
	public async Task<string> Login(string email, string password)
	{
		var user = _userRepository.GetByEmail(email);
		var result = _passwordHasher.Verify(password, user.PasswordHashed);
		if (result == false)
		{
			throw new Exception("Incorrect email or password");
		}
		return "";
	}
}
//pattern