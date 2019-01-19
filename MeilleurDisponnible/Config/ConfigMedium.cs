using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeilleurDisponnible.Config
{
    public class ConfigMedium : IConfig
    {
        public readonly int _timeLoopDelay = 5;

        public readonly uint statMinValue = 0;
        public readonly uint statMaxValue = 100;

        public readonly uint _startingFedLevel = 50;
        public readonly uint _startingHydratationLevel = 50;
        public readonly uint _startingGamingLevel = 50;
        public readonly uint _startingEnergyLevel = 50;
        public readonly uint _startingHealthLevel = 50;

        public readonly uint _lowStatTrigger = 15;

        public readonly uint _statMaxModifier = 2;
        public readonly uint _statMinModifier = 1;
        public readonly uint _statHealthMaxDamage = 5;
        public readonly uint _statHealthMinDamage = 1;
        public readonly uint _statHealthMaxGain = 2;
        public readonly uint _statHealthMinGain = 1;
        public readonly uint _statActionMaxModifier = 20;
        public readonly uint _statActionMinModifier = 10;
    }
}
