using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeilleurDisponnible.Models.Game
{
    public interface IGameRepository
    {
        List<GameEntity> GetGames();
        List<GameEntity> GetGamesByUser(UserEntity user);
        GameEntity GetGame(int id);
        void CreateGame(GameEntity game);
        void UpdateGame(GameEntity game);
        void DeleteGame(GameEntity game);
        int SaveGame();
    }
}
