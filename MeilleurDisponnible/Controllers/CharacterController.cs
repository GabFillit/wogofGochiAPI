using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using MeilleurDisponnible.CustomMapper;
using MeilleurDisponnible.Models.Character;
using MeilleurDisponnible.Models.Game;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeilleurDisponnible.Controllers
{
    [Route("api/user/{userId}/game/{gameId}/character")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        public ICharacterService _characterService;
        public IGameRepository _gameRepository;
        public IValidator<Character> _characterValidator;
        public Mapper _mapper;

        public CharacterController(IValidator<Character> characterValidator, ICharacterService characterService, IGameRepository gameRepository)
        {
            _characterService = characterService;
            _gameRepository = gameRepository;
            _characterValidator = characterValidator;
            _mapper = new Mapper();
        }

        // GET: api/user/{userId}/game/{gameId}/character
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_characterService.GetCharacters());
        }

        // GET: api/Character/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            Character character = _characterService.GetCharacter(id);
            if (character == null)
            {
                return NotFound();
            }
            return Ok(character);
        }

        // POST: api/user/{userId}/game/{gameId}/character
        [HttpPost]
        public IActionResult Post(int gameId, [FromBody] CreateCharacterDTO createCharacterDTO)
        {
            var game = _gameRepository.GetGame(gameId);
            if (game == null)
            {
                return NotFound();
            }

            Character character = _mapper.Map<Character>(createCharacterDTO);
            character.Game = game;

            var valid = _characterValidator.Validate(character);
            if (!valid.IsValid)
            {
                return BadRequest();
            }

            _characterService.CreateCharacter(character, game);

            if (_characterService.SaveCharacter() > 0)
            {
                return Ok();
            }
            return BadRequest();
        }

        // PUT: api/Character/5
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
