using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeilleurDisponnible.Models.Character
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly MeilleurDisponnibleContext _context;

        public CharacterRepository(MeilleurDisponnibleContext context)
        {
            _context = context;
        }

        public Character AddCharacter(Character character)
        {
            _context.CharacterEntity
                .Add(character);

            return character;
        }
    }
}
