using MeilleurDisponnible.Models.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeilleurDisponnible.Models.Stats
{
    public class StatsEntity : EntityBase
    {
        public int CharacterId { get; set; }
        public int Current { get; set; }
        public StatsType Type { get; set; }

        public StatsEntity(int characterId, StatsType type)
        {
            CharacterId = characterId;

            //TODO: CONFIG file
            Current = 50;

            Type = type;
        }
    }
}
