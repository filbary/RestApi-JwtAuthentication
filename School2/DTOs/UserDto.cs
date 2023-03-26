using FluentValidation;
using MongoDB.Bson.Serialization.Attributes;
using School2.Extensions;

namespace School2.DTOs
{
    public class UserDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public List<string> Roles { get; set; }

        public UserDto()
        {
            Roles = new();
        }
    }

    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(x => x.FirstName).IsName();
            RuleFor(x => x.LastName).IsName();
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Roles).IsInRoles();
        }
    }
}
