using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeilleurDisponnible.Models.Game
{
    public class GameRepository : IGameRepository
    {
        public static List<GameEntity> GameList { get; set; }

        public GameEntity GetGame(int id)
        {
            throw new NotImplementedException();
        }

        public List<GameEntity> GetGames()
        {
            throw new NotImplementedException();
        }
    }
}
