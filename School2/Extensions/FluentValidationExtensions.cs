using FluentValidation;
using System.Reflection;
using static School2.Helpers.Consts;

namespace School2.Extensions
{
    public static class FluentValidationExtensions
    {
        public static IRuleBuilderOptions<T, string> IsName<T>(this IRuleBuilder<T, string> rule)
            => rule.Matches(@"^[a-zA-Z]+$");
        public static IRuleBuilderOptions<T, IEnumerable<string>> IsInRoles<T>(this IRuleBuilder<T, IEnumerable<string>> rule)
        {
            var roles = typeof(Roles).GetFields().Select(x => x.Name).ToList();
            return rule.Must(x => x.All(x => roles.Contains(x)));
        }
    }
}
