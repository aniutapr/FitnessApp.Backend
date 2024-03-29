using System;
using System.Threading.Tasks;
using FitnessApp.Contracts.Interfaces.Repositories;
using FitnessApp.Contracts.Interfaces.Services;
using FitnessApp.Domain.Entities;

namespace FitnessApp.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserRepository _userRepository;
        private readonly IJwtProvider _jwtProvider;

        public UserService(IPasswordHasher hasher, IUserRepository repository, IJwtProvider jwtProvider)
        {
            _passwordHasher = hasher ?? throw new ArgumentNullException(nameof(hasher));
            _userRepository = repository ?? throw new ArgumentNullException(nameof(repository));
            _jwtProvider = jwtProvider ?? throw new ArgumentNullException(nameof(jwtProvider));
        }

        public async Task Register(string username, string email, string password, Role role)
        {
            var hashedPassword = _passwordHasher.Generate(password);
            var user = User.Create(Guid.NewGuid(), username, hashedPassword, email, new List<Role> { role });
            await _userRepository.AddUser(user);
        }

        public async Task<string> Login(string email, string password)
        {
            var user = await _userRepository.GetByEmail(email);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            var result = _passwordHasher.Verify(password, user.PasswordHashed);
            if (!result)
            {
                throw new Exception("Incorrect password");
            }

            var token = _jwtProvider.GenerateToken(user);
            return token;
        }
    }
}
