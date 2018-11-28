using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeilleurDisponnible.Models.Game
{
    public class GameRepository : IGameRepository
    {
        public MeilleurDisponnibleContext _context;

        public GameRepository(MeilleurDisponnibleContext context)
        {
            _context = context;
        }

        public List<GameEntity> GetGames()
        {
            var games = _context.GameEntity.ToList();
            return games;
        }

        public List<GameEntity> GetGamesByUser(int userId)
        {
            var games = _context.GameEntity
                .Where<GameEntity>(g => g.UserId == userId)
                .ToList();
            return games;
        }

        public GameEntity GetGame(int userId, int id)
        {
            var game = _context.GameEntity
                            .FirstOrDefault<GameEntity>(g => g.UserId == userId && g.Id == id);
            return game;
        }

        public void CreateGame(int userId, string name)
        {
            _context.GameEntity
                .Add(new GameEntity { UserId = userId, Name = name });
            _context.SaveChanges();
        }
    }
}
