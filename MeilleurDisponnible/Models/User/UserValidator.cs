using FluentValidation;
using MeilleurDisponnible.Models;

namespace MeilleurDisponnible
{
    public class UserValidator : AbstractValidator<UserEntity>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name).Length(0, 25);
        }
    }
}