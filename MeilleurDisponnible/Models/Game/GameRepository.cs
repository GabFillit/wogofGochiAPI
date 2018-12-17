﻿using System;
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
                .Where(g => g.UserId == userId)
                .ToList();
            return games;
        }

        public GameEntity GetGame(int id)
        {
            var game = _context.GameEntity
                            .FirstOrDefault(g => g.Id == id);
            return game;
        }

        public void CreateGame(GameEntity game)
        {
            _context.GameEntity
                .Add(game);
        }

        public void UpdateGame(GameEntity game)
        {
            _context.Update(game);
        }

        public void DeleteGame(GameEntity game)
        {
            _context.Remove(game);
        }

        public int SaveGame()
        {
            return _context.SaveChanges();
        }
    }
}
