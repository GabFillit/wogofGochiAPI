using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeilleurDisponnible.Models.Character
{
    public class CharacterValidator : AbstractValidator<Character>
    {
        public CharacterValidator()
        {
            RuleFor(x => x.Name).Length(0, 25);
            RuleFor(x => x.CurrentStatus).IsInEnum();
        }
    }
}
