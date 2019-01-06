using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using MeilleurDisponnible.CustomMapper;
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
        public IValidator<GameEntity> _gameValidator;
        public Mapper _mapper;

        public GameController(IGameRepository gameRepository, IUserRepository userRepository, IValidator<GameEntity> gameValidator)
        {
            _gameRepository = gameRepository;
            _userRepository = userRepository;
            _gameValidator = gameValidator;
            _mapper = new Mapper();
        }

        // GET: api/Game
        //[HttpGet]
        //public IActionResult Get()
        //{
        //    return Ok(_gameRepository.GetGames());
        //}

        // GET: api/user/1/Game
        [HttpGet]
        public IActionResult GetUserGames(int userId)
        {
            var user = _userRepository.GetUser(userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(_gameRepository.GetGamesByUser(user));
        }

        // GET: api/user/1/Game/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
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
        public IActionResult Post(int userId, [FromBody] CreateGameDTO createGameDTO)
        {
            GameEntity game = _mapper.Map<GameEntity>(createGameDTO);

            var user = _userRepository.GetUser(userId);
            if (user == null)
            {
                return NotFound();
            }

            game.User = user;

            var valid = _gameValidator.Validate(game);
            if (!valid.IsValid)
            {
                return BadRequest();
            }

            _gameRepository.CreateGame(game);

            if (_gameRepository.SaveGame()>0)
            {
                return Ok();
            }
            return BadRequest();
        }

        // PUT: api/
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateGameDTO updateGameDTO)
        {
            var valid = _gameValidator.Validate(updateGameDTO);
            if (!valid.IsValid)
            {
                return BadRequest();
            }

            GameEntity game = _gameRepository.GetGame(id);
            if (game == null)
            {
                return NotFound();
            }

            game.Name = updateGameDTO.name;
            game.Status = updateGameDTO.status;

            if (_gameRepository.SaveGame() > 0)
            {
                return Ok();
            }
            return BadRequest();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            GameEntity game = _gameRepository.GetGame(id);
            if (game == null)
            {
                return NotFound();
            }

            _gameRepository.DeleteGame(game);

            if (_gameRepository.SaveGame()>0)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
