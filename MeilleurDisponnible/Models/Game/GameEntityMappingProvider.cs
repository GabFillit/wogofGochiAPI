using MeilleurDisponnible.CustomMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeilleurDisponnible.Models.Game
{
    public class GameEntityMappingProvider : IMappingProvider
    {
        public TDestination Map<TDestination>(object input)
        {
            object game = null;

            if (input is CreateGameDTO)
            {
                game = Map((CreateGameDTO)input);
            }

            return (TDestination)game;
        }

        private GameEntity Map(CreateGameDTO input)
        {
            GameEntity game = new GameEntity
            {
                Name = input.name
            };
            return game;
        }
    }
}
