using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeilleurDisponnible.Models.Character
{
    public interface ICharacterService
    {
        List<Character> GetCharacters();
        void CreateCharacter(Character character, Game.Game game);
        bool HandleStatusUpdate(Character character);
        void Manger(Character character, UpdateCharacterDTO<Foods> updateCharacterDTO);
        int GetFactor(DateTime lastUpdate);
    }
}
