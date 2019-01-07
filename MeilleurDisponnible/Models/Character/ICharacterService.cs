using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeilleurDisponnible.Models.Character
{
    public interface ICharacterService
    {
        List<Character> GetCharacters();
        Character GetCharacter(int id);
        void CreateCharacter(Character character, Game.Game game);
        int SaveCharacter();
    }
}
