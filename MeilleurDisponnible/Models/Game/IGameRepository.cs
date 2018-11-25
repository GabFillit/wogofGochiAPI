using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeilleurDisponnible.Models.Game
{
    public interface IGameRepository
    {
        List<GameEntity> GetGames();
        List<GameEntity> GetGamesByUser(int userId);
        GameEntity GetGame(int id);
    }
}
