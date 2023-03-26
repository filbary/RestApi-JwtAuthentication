using School2.DTOs;
using School2.Repositories.Models;

namespace School2.Services.Interfaces
{
    public interface IUserService
    {
        public Task<User> GetUserByEmailAsync(string email);
        public Task CreateNewUser(UserDto userDto);
        public Task RegisterUser(UserCredDto userDto);
        public Task<User> GetByUsername(string username);
        public Task<IEnumerable<User>> GetAllUsers();
    }
}
