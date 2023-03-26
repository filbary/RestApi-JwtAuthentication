using MongoDB.Bson.Serialization.Attributes;
using School2.Helpers;
using static School2.Helpers.Consts;

namespace School2.Repositories.Models
{
    [BsonCollection(MongoDb.Users)]
    public class User : Document
    {
        [BsonRequired]
        public string Username { get; set; }
        [BsonRequired]
        public byte[] Password { get; set; }
        [BsonRequired]
        public byte[] PasswordSalt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public List<string> Roles { get; set; }
        public User()
        {
            Roles = new();
        }

    }
}
