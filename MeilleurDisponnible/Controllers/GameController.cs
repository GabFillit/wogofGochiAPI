using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeilleurDisponnible.Models.Game;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeilleurDisponnible.Controllers
{
    [Route("api/user/{userId:int}/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        public IGameRepository _gameRepository;

        public GameController(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        // GET: api/Game
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_gameRepository.GetGames());
        }

        // GET: api/user/1/Game
        [HttpGet]
        public IActionResult Get([FromRoute] int userId)
        {
            return Ok(_gameRepository.GetGamesByUser(userId));
        }

        // GET: api/user/1/Game/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get([FromRoute] int userId, int id)
        {
            GameEntity game = _gameRepository.GetGame(userId, id);
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
            if (String.IsNullOrEmpty(name))
            {
                return BadRequest();
            }
            //if no userid return not foud
            _gameRepository.CreateGame(userId, name);
            return Ok();
        }

        // PUT: api/Game/5
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
