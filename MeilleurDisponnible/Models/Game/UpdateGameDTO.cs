using MeilleurDisponnible.CustomMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeilleurDisponnible.Models.Game
{
    public class UpdateGameDTO : IMappable
    {
        public string name { get; set; }    
        public GameStatus status { get; set; }
    }
}
