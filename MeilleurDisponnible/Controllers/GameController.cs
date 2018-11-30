using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeilleurDisponnible.Models.Game;
using MeilleurDisponnible.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeilleurDisponnible.Controllers
{
    [Route("api/user/{userId}/game")]
    [ApiController]
    public class GameController : ControllerBase
    {
        public IGameRepository _gameRepository;
        public IUserRepository _userRepository;

        public GameController(IGameRepository gameRepository, IUserRepository userRepository)
        {
            _gameRepository = gameRepository;
            _userRepository = userRepository;
        }

        // GET: api/Game
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_gameRepository.GetGames());
        }

        // GET: api/user/1/Game
        [HttpGet]
        public IActionResult GetUserGames(int userId)
        {
            return Ok(_gameRepository.GetGamesByUser(userId));
        }

        // GET: api/user/1/Game/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int userId, int id)
        {
            GameEntity game = _gameRepository.GetGame(id);
            if (game == null)
            {
                return NotFound();
            }
            return Ok(game);
        }

        // POST: api/user/1/Game
        [HttpPost()]
        public IActionResult Post(int userId, [FromBody] string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest();
            }

            var user = _userRepository.GetUser(userId);
            if (user == null)
            {
                return NotFound();
            }

            GameEntity game = new GameEntity(user, name);
            _gameRepository.CreateGame(game);

            return Ok();
        }

        // PUT: api/
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
