using MeilleurDisponnible.Models.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeilleurDisponnible.Stats
{
    public class Stat
    {
        public uint Min { get; set; }
        public uint Max { get; set; }
        public uint Current { get; set; }
        public Character CharacterEntity { get; set; }


        public Stat(uint current, uint min, uint max)
        {
            Min = min;
            Max = max;
            Current = current;
        }

        public void AddCurrent(uint value)
        {
            if ((Current += value) > Max)
            {
                Current = Max;
            }
        }

        public void RemoveCurrent(uint value)
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
