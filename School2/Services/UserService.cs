using School2.DTOs;
using School2.Extensions;
using School2.Repositories.Interfaces;
using School2.Repositories.Models;
using School2.Services.Interfaces;

namespace School2.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetUserByEmailAsync(email);
        }

        public async Task CreateNewUser(UserDto dto)
        {
            var usernameExists = await GetByUsername(dto.Username) != null;
            if (usernameExists)
            {
                throw new Exception("Username already exists");
            }
            dto.Password.CreatePasswordHash(out byte[] passwordHash, out byte[] passwordSalt);
            var user = new User
            {
                Username = dto.Username,
                Password = passwordHash,
                PasswordSalt = passwordSalt,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                BirthDate = dto.BirthDate,
                Roles = dto.Roles
            };
            await _userRepository.InsertOneAsync(user);
        }

        public async Task RegisterUser(UserCredDto userDto)
        {
            var usernameExists = await GetByUsername(userDto.Username) != null;
            if (usernameExists)
            {
                throw new Exception("Username already exists");
            }
            userDto.Password.CreatePasswordHash(out byte[] passwordHash, out byte[] passwordSalt);
            var user = new User
            {
                Username = userDto.Username,
                Password = passwordHash,
                PasswordSalt = passwordSalt
            };
            await _userRepository.InsertOneAsync(user);
        }

        public async Task<User> GetByUsername(string username)
        {
            return await _userRepository.FindOneByParamAsync(nameof(User.Username), username);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userRepository.GetAll();
        }
    }
}
