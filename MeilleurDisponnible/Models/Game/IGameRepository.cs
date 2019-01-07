using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeilleurDisponnible.Models.Game
{
    public interface IGameRepository
    {
        List<Game> GetGames();
        List<Game> GetGamesByUser(UserEntity user);
        Game GetGame(int id);
        void CreateGame(Game game);
        void UpdateGame(Game game);
        void DeleteGame(Game game);
        int SaveGame();
    }
}
