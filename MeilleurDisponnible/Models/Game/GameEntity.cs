using MeilleurDisponnible.Models.Character;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeilleurDisponnible.Models.Game
{
    public class Game : EntityBase
    {
        public int UserId { get; set; }
        public UserEntity User { get; set; }

        public int CharacterId { get; set; }
        public Character.Character Character { get; set; }

        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public GameStatus Status { get; set; }

        public Game()
        {
            StartDate = DateTime.Now;
            Status = GameStatus.Created;
        }

        public Game(UserEntity user, string name) : base()
        {
            User = user;
            User = user;
            Name = name;
        }


    }
}
