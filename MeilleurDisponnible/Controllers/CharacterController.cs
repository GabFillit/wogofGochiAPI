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
        private readonly ICharacterRepository _characterRepository;
        public IValidator<Character> _characterValidator;
        public Mapper _mapper;

        public CharacterController(IValidator<Character> characterValidator, ICharacterService characterService, IGameRepository gameRepository, ICharacterRepository characterRepository)
        {
            _characterService = characterService;
            _gameRepository = gameRepository;
            _characterRepository = characterRepository;
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
            Character character = _characterRepository.GetCharacter(id);
            if (character == null)
            {
                return NotFound();
            }

            character = _characterService.Update(character);

            _characterRepository.SaveCharacter();
           
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

            if (_characterRepository.SaveCharacter() > 0)
            {
                return Ok();
            }
            return BadRequest();
        }

        // PUT: api/Character/5/manger
        [HttpPut("{id}/manger")]
        public IActionResult Manger(int id, [FromBody] int choice)
        {
            Character character = _characterRepository.GetCharacter(id);
            if (character == null)
            {
                return NotFound();
            }

            _characterService.Manger(character, (Foods)choice);

            if (_characterRepository.SaveCharacter() > 0)
            {
                return Ok();
            }

            return BadRequest();
        }

        // PUT: api/Character/5/boire
        [HttpPut("{id}/boire")]
        public IActionResult Boire(int id, [FromBody] int choice)
        {
            Character character = _characterRepository.GetCharacter(id);
            if (character == null)
            {
                return NotFound();
            }

            _characterService.Boire(character, (Drinks)choice);

            if (_characterRepository.SaveCharacter() > 0)
            {
                return Ok();
            }

            return BadRequest();
        }

        // PUT: api/Character/5/dormir
        [HttpPut("{id}/dormir")]
        public IActionResult Dormir(int id)
        {
            Character character = _characterRepository.GetCharacter(id);
            if (character == null)
            {
                return NotFound();
            }

            _characterService.Dormir(character);

            if (_characterRepository.SaveCharacter() > 0)
            {
                return Ok();
            }

            return BadRequest();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Character character = _characterRepository.GetCharacter(id);
            if (character == null)
            {
                return NotFound();
            }

            _characterRepository.DeleteCharacter(character);
            if (_characterRepository.SaveCharacter() > 0)
            {
                return Ok(character);
            }

            return BadRequest();
        }
    }
}
