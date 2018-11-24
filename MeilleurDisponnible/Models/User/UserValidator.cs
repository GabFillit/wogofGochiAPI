using FluentValidation;

namespace MeilleurDisponnible
{
    public class UserValidator : AbstractValidator<Models.UserEntity>
    {
        public UserValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).Length(0, 25);
        }
    }
}