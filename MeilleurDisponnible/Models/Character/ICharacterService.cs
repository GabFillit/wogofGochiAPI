using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeilleurDisponnible.Models.Character
{
    public interface ICharacterService
    {
        List<CharacterEntity> GetCharacters();
        CharacterEntity GetCharacter(int id);
        void CreateCharacter(CharacterEntity character);
        int SaveCharacter();
    }
}
