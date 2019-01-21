using MeilleurDisponnible.Models.Game;
using MeilleurDisponnible.Models.Stats;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeilleurDisponnible.Models.Character
{
    public class Character : EntityBase
    {
        public Game.Game Game { get; set; }
        public int GameId { get; set; }

        public string Name { get; set; }
        public Status CurrentStatus { get; set; }
        public IList<Stat> Stats { get; set; }
        public DateTime LastUpdate { get; set; }

        [NotMapped]
        public Stat Health
        {
            get { return Stats.FirstOrDefault(s => s.Type == StatsType.Health); }
        }

        [NotMapped]
        public Stat Thirst
        {
            get { return Stats.FirstOrDefault(s => s.Type == StatsType.Thirst); }
        }

        [NotMapped]
        public Stat Hunger
        {
            get { return Stats.FirstOrDefault(s => s.Type == StatsType.Hunger); }
        }

        [NotMapped]
        public Stat Energy
        {
            get { return Stats.FirstOrDefault(s => s.Type == StatsType.Energy); }
        }

        [NotMapped]
        public Stat Custom1
        {
            get { return Stats.FirstOrDefault(s => s.Type == StatsType.Custom1); }
        }

        [NotMapped]
        public Stat Custom2
        {
            get { return Stats.FirstOrDefault(s => s.Type == StatsType.Custom2); }
        }

        [NotMapped]
        public bool IsAlive
        {
            get { return Health.Current > Health.Min; }
        }

        [NotMapped]
        public bool IsTired
        {
            get { return Energy.Current == Energy.Max; }

        }


        public Character()
        {
            CurrentStatus = Status.Idle;
            LastUpdate = DateTime.UtcNow;
        }
    }
}

