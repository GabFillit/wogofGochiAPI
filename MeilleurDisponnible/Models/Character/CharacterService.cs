using MeilleurDisponnible.Models.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeilleurDisponnible.Models.Character
{
    public class CharacterService : ICharacterService
    {
        private MeilleurDisponnibleContext _context;
        private readonly ICharacterRepository _characterRepository;

        public CharacterService(MeilleurDisponnibleContext context, ICharacterRepository characterRepository)
        {
            _context = context;
            _characterRepository = characterRepository;
        }

        public List<Character> GetCharacters()
        {
            var character = _context.CharacterEntity.ToList();
            return character;
        }

        public Character GetCharacter(int id)
        {
            var character = _context.CharacterEntity
                .FirstOrDefault(u => u.Id == id);
            return character;
        }

        public void CreateCharacter(Character character, Game.Game game)
        {
            character.Game = game;

            character.Stats
               .Add(new Stat(StatsType.Hunger)); //System.NullReferenceException: 'Object reference not set to an instance of an object.'
            character.Stats
               .Add(new Stat(StatsType.Thirst));
            character.Stats
               .Add(new Stat(StatsType.Energy));
            character.Stats
               .Add(new Stat(StatsType.Health));

            _characterRepository.AddCharacter(character);
        }

        public int SaveCharacter()
        {
            return _context.SaveChanges();
        }
    }
}
