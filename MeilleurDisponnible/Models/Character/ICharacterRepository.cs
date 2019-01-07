using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeilleurDisponnible.Models.Character
{
    public interface ICharacterRepository
    {
        Character AddCharacter(Character character);
    }
}
