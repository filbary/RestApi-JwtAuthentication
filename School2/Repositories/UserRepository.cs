using Microsoft.Extensions.Options;
using School2.ConfigModels;
using School2.Repositories.Interfaces;
using School2.Repositories.Models;

namespace School2.Repositories
{
    public class UserRepository : MongoDbRepository<User>, IUserRepository
    {
        public UserRepository(IOptions<MongoSettings> settings) : base(settings)
        {

        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await FindOneByParamAsync(nameof(User.Email), email);
        }

        public async Task<User> GetUsersBySurnameAsync(string name)
        {
            return await FindOneByParamAsync(nameof(User.LastName), name);
        }
    }
}
