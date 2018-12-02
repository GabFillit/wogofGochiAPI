using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeilleurDisponnible.CustomMapper
{
    public class Mapper
    {
        public IMappingProvider MappingProvider { get; private set; }

        public Mapper( IMappingProvider provider )
        {
            MappingProvider = provider;
        }

        public T Map<T>(IMappable input)
        {
            return MappingProvider.Map<T>(input);
        }
    }
}
