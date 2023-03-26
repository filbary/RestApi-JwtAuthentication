using School2.Repositories.Models;

namespace School2.Repositories.Interfaces
{
    public interface IUserRepository : IMongoDbRepository<User>
    {
        public Task<User> GetUserByEmailAsync(string email);
        public Task<User> GetUsersBySurnameAsync(string name);
    }
}
