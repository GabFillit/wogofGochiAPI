using MeilleurDisponnible.Models.Game;
using MeilleurDisponnible.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeilleurDisponnible.Models.Character
{
    public class CharacterEntity : EntityBase
    {
        public string Name { get; private set; }
        public Status CurrentStatus { get; protected set; }
        public List<Stat> Stats { get; set; }
        public GameEntity Game { get; set; }

        public CharacterEntity()
        {
            CurrentStatus = Status.Idle;
        }
    }

}
}
