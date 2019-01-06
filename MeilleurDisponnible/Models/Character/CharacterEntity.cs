using MeilleurDisponnible.Models.Game;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeilleurDisponnible.Models.Character
{
    public class CharacterEntity
    {
        [Key]
        public int Id { get; set; }

        public GameEntity Game { get; set; }

        public string Name { get; set; }
        public Status CurrentStatus { get; protected set; }

        public CharacterEntity()
        {
            CurrentStatus = Status.Idle;
        }
    }
}

