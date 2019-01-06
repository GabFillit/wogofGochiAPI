using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeilleurDisponnible.Models.Game
{
    public class GameEntity : EntityBase
    {
        
        public UserEntity User { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public GameStatus Status { get; set; }

        public GameEntity()
        {
            StartDate = DateTime.Now;
            Status = GameStatus.Created;
        }

        public GameEntity(UserEntity user, string name) : base()
        {
            User = user;
            User = user;
            Name = name;
        }


    }
}
