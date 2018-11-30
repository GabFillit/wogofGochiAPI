using FluentValidation;

namespace MeilleurDisponnible
{
    public class UserValidator : AbstractValidator<Models.UserEntity>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name).Length(0, 25);
        }
    }
}