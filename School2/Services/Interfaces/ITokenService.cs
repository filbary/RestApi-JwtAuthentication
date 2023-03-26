using School2.Repositories.Models;

namespace School2.Services.Interfaces
{
    public interface ITokenService
    {
        public string CreateToken(User user);
    }
}
