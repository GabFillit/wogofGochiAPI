using MeilleurDisponnible.Models.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeilleurDisponnible.Models.Character
{
    public class CharacterService : ICharacterService
    {
        public MeilleurDisponnibleContext _context;

        public CharacterService(MeilleurDisponnibleContext context)
        {
            _context = context;
        }

        public List<CharacterEntity> GetCharacters()
        {
            var character = _context.CharacterEntity.ToList();
            return character;
        }

        public CharacterEntity GetCharacter(int id)
        {
            var character = _context.CharacterEntity
                .FirstOrDefault(u => u.Id == id);
            return character;
        }

        public void CreateCharacter(CharacterEntity character)
        {
            _context.CharacterEntity   
              .Add(character);
            _context.Stats
               .Add(new StatsEntity(character.Id, StatsType.Hunger));
            _context.Stats
               .Add(new StatsEntity(character.Id, StatsType.Thirst));
            _context.Stats
               .Add(new StatsEntity(character.Id, StatsType.Energy));
            _context.Stats
               .Add(new StatsEntity(character.Id, StatsType.Health));
        }

        public int SaveCharacter()
        {
            return _context.SaveChanges();
        }
    }
}
