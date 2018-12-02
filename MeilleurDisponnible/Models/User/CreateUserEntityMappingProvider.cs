using MeilleurDisponnible.CustomMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeilleurDisponnible.Models.User
{
    public class CreateUserEntityMappingProvider : IMappingProvider
    {
        public T Map<T>(IMappable input)
        {
            object result = map(input as CreateUserDTO);
            return (T)result;
        }

        private UserEntity map(CreateUserDTO input)
        {
            UserEntity user = new UserEntity(input.name);
            return user;
        }
    }
}
