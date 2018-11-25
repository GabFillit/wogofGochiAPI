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

        // GET: api/user/Game
        [HttpGet]
        public IActionResult Get([FromRoute] int userId)
        {
            return Ok(_gameRepository.GetGamesByUser(userId));
        }

        // GET: api/Game/5
        [HttpGet("{id}", Name = "Get")]
        public string Get([FromRoute] int userId, int id)
        {
            return "value";
        }

        // POST: api/Game
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
