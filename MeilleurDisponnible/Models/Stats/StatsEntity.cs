using MeilleurDisponnible.Models.Character;
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
        public int Min { get; set; }
        public int Max { get; set; }
        public StatsType Type { get; set; }

        public Stat(StatsType type)
        {
            //TODO: CONFIG file
            Current = 50;
            Min = 0;
            Max = 100;

            Type = type;
        }

        public void AddCurrent(int value)
        {
            if ((Current += value) > Max)
            {
                Current = Max;
            }
        }

        public void RemoveCurrent(int value)
        {
            if (value > Current)
            {
                Current = Min;
            }
            else
            {
                Current -= value;
            }
        }
    }
}
