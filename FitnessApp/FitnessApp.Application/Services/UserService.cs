using FitnessApp.Contracts.Interfaces.Repositories;
using FitnessApp.Contracts.Interfaces.Services;
using FitnessApp.Domain.Entities;

namespace FitnessApp.Application.Services;

public class UserService:IUserService
{
	private readonly IPasswordHasher _passwordHasher;
    private IUserRepository _userRepository;
    private IJwtProvider _jwtProvider;

    public UserService(IPasswordHasher hasher, IUserRepository repository, IJwtProvider jwtProvider)
	{
		_passwordHasher = hasher;
		_userRepository = repository;
		_jwtProvider = jwtProvider;
	}
	public async Task Register(string username, string email, string password)
	{
		var hashedPassword = _passwordHasher.Generate(password);
		var user = User.Create(Guid.NewGuid(), username, hashedPassword, email);
		await _userRepository.AddUser(user);

	}
	public async Task<string> Login(string email, string password)
	{
		var user = await _userRepository.GetByEmail(email);
		var result = _passwordHasher.Verify(password, user.PasswordHashed);
		if (result == false)
		{
			throw new Exception("Incorrect email or password");
		}
		var token = _jwtProvider.GenerateToken(user);
		return token;
	}
}
//pattern