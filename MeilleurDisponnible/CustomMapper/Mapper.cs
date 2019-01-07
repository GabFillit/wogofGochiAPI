using MeilleurDisponnible.Models;
using MeilleurDisponnible.Models.Character;
using MeilleurDisponnible.Models.Game;
using MeilleurDisponnible.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeilleurDisponnible.CustomMapper
{
    public class Mapper
    {

        private Dictionary<Type, Lazy<IMappingProvider>> _mappingProviders;

        public Mapper()
        {
            _mappingProviders = new Dictionary<Type, Lazy<IMappingProvider>>
            {
                { typeof(UserEntity), new Lazy<IMappingProvider>(() => new UserEntityMappingProvider()) },
                { typeof(Game), new Lazy<IMappingProvider>(() => new GameEntityMappingProvider()) },
                { typeof(Character), new Lazy<IMappingProvider>(() => new CharacterEntityMappingProvider()) }
            };

        }

        public TDestination Map<TDestination>(IMappable input)
        {
            var specificProvider = _mappingProviders[typeof(TDestination)].Value;

            return specificProvider.Map<TDestination>(input);
        }
    }
}
