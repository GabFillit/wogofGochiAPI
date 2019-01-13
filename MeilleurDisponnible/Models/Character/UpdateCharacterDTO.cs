using MeilleurDisponnible.CustomMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeilleurDisponnible.Models.Character
{
    public class UpdateCharacterDTO<T>
    {
        public Actions action { get; set; }
        public T selection { get; set; }
    }
}
