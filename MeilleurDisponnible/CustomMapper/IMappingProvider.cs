using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeilleurDisponnible.CustomMapper
{
    public interface IMappingProvider
    {
        T Map<T>(IMappable input);
    }
}
