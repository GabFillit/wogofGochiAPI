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

        public Character GetCharacter(int id)
        {
            var character = _context.CharacterEntity
                .FirstOrDefault(u => u.Id == id);
            return character;
        }

        public Character AddCharacter(Character character)
        {
            _context.CharacterEntity
                .Add(character);

            return character;
        }

        public void DeleteCharacter(Character character)
        {
            _context.Remove(character);
        }

        public int SaveCharacter()
        {
            return _context.SaveChanges();
        }
    }
}
