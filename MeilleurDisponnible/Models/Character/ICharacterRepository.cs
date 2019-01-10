using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeilleurDisponnible.Models.Character
{
    public interface ICharacterRepository
    {
        Character GetCharacter(int id);
        Character AddCharacter(Character character);
        void DeleteCharacter(Character character);
        int SaveCharacter();
    }
}
