using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeilleurDisponnible.Models.Game
{
    public class GameValidator : AbstractValidator<GameEntity>
    {
        public GameValidator()
        {
            RuleFor(x => x.Name).Length(0, 25);
            RuleFor(x => x.Status).IsInEnum();
        }
    }
}
