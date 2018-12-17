using MeilleurDisponnible.CustomMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeilleurDisponnible.Models.User
{
    public class UserEntityMappingProvider : IMappingProvider
    {

        public TDestination Map<TDestination>(object input)
        {
            object user = null;

            if (input is CreateUserDTO)
            {
                user = Map((CreateUserDTO)input);
            }

            return (TDestination)user;
        }

        private UserEntity Map(CreateUserDTO input)
        {
            UserEntity user = new UserEntity
            {
                Name = input.name
            };
            return user;
        }
    }
}
