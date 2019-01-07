﻿using MeilleurDisponnible.Models.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeilleurDisponnible.Models.Stats
{
    public class Stat : EntityBase
    {
        public int CharacterId { get; set; }
        public Character.Character Character { get; set; }
        public int Current { get; set; }
        public StatsType Type { get; set; }

        public Stat(StatsType type)
        {
            //TODO: CONFIG file
            Current = 50;

            Type = type;
        }
    }
}
