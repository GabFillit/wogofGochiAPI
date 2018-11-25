using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeilleurDisponnible.Models.Game
{
    public class GameEntity : EntityBase
    {
        [ForeignKey("UserEntity")]
        public int UserId { get; set; }

        public DateTime StartDate { get; set; }
        public string Name { get; set; }
        public GameStatus Status { get; set; }
    }
}
