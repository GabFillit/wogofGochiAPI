using MeilleurDisponnible.Models.Game;
using MeilleurDisponnible.Models.Stats;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public IList<Stat> Stats{ get; set; }
        public DateTime LastUpdate { get; set; }

        public Character()
        {
            CurrentStatus = Status.Idle;
            LastUpdate = DateTime.UtcNow;
        }
    }
}

