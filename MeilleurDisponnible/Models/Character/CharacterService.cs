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

        public void CreateCharacter(Character character, Game.Game game)
        {
            character.Game = game;
            character.Stats = new List<Stat>
            {
                new Stat(StatsType.Hunger),
                new Stat(StatsType.Thirst),
                new Stat(StatsType.Energy),
                new Stat(StatsType.Health)
            };

            _characterRepository.AddCharacter(character);
        }



        public void Manger(Character character, UpdateCharacterDTO<Foods> updateCharacterDTO)
        {
            
        }

        public bool HandleStatusUpdate(Character character)
        {
            var factor = GetFactor(character.LastUpdate);

            if (factor==0)
            {
                return true;
            }


        }

        public int GetFactor(DateTime lastUpdate)
        {
            var deltaTime = lastUpdate - DateTime.UtcNow;
            return (int)Math.Floor(deltaTime.TotalSeconds / 5);
        }
    }
}
