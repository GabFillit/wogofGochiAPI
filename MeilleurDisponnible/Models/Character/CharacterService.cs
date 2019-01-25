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

        public Character Update(Character character)
        {
            character = HandleStatusUpdate(character);
            _characterRepository.AddCharacter(character);

            return character;
        }

        public Character Manger(Character character, Foods selection)
        {
            character = HandleStatusUpdate(character);

            //TODO : Like and dislike list in config
            character.Hunger.AddCurrent(20);

            _characterRepository.AddCharacter(character);

            return character;
        }

        public Character Boire(Character character, Drinks choice)
        {
            character = HandleStatusUpdate(character);

            //TODO : Like and dislike list in config
            character.Thirst.AddCurrent(20);

            _characterRepository.AddCharacter(character);

            return character;
        }

        public Character Dormir(Character character)
        {
            character = HandleStatusUpdate(character);

            switch (character.CurrentStatus)
            {
                case Status.Idle:
                    character.CurrentStatus = Status.Sleeping;
                    break;
                case Status.Sleeping:
                    character.CurrentStatus = Status.Idle;
                    break;
                case Status.Dead:
                    return character;
                default:
                    break;
            }

            _characterRepository.AddCharacter(character);

            return character;
        }

        public Character HandleStatusUpdate(Character character)
        {
            var factor = GetFactor(character.LastUpdate);

            if (factor == 0)
            {
                return character;
            }

            if (!character.IsAlive)
            {
                character.CurrentStatus = Status.Dead;
            }

            for (int i = 0; i < factor; i++)
            {
                switch (character.CurrentStatus)
                {
                    case Status.Idle:
                        //TODO: config energy lost per update when idle
                        character.Energy.RemoveCurrent(1);
                        //TODO: config hunger lost per update when idle
                        character.Hunger.RemoveCurrent(1);
                        //TODO: config thirst lost per update when idle
                        character.Thirst.RemoveCurrent(1);
                        break;
                    case Status.Sleeping:
                        //TODO: energy level gain when sleep
                        character.Energy.AddCurrent(2);
                        //TODO: config hunger lost per update when sleep
                        character.Hunger.RemoveCurrent(1);
                        //TODO: config thirst lost per update when sleep
                        character.Thirst.RemoveCurrent(1);

                        if (character.IsTired)
                        {
                            character.CurrentStatus = Status.Idle;
                        }
                        break;
                    case Status.Dead:
                        return character;
                    //TODO: case for custom stats
                    default:
                        break;
                }

                character = CalculHealthUpdate(character);
            }

            //TODO: characte.lastUpdate config time
            character.LastUpdate.AddSeconds(factor * 5);
            
            return character;
        }

        public int GetFactor(DateTime lastUpdate)
        {
            var deltaTime = lastUpdate - DateTime.UtcNow;
            return (int)Math.Floor(deltaTime.TotalSeconds / 5);
        }

        //TODO: config shits
        public Character CalculHealthUpdate(Character character)
        {
            bool hurt = false;
            if (character.IsHungry)
            {
                character.Health.RemoveCurrent(2);
                hurt = true;
            }
            if (character.IsThirsty)
            {
                character.Health.RemoveCurrent(2);
                hurt = true;
            }
            if (!hurt)
            {
                character.Health.AddCurrent(2);
            }
            return character;
        }
    }
}
