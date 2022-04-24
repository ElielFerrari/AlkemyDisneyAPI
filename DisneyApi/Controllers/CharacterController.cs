using BusinessLogic.Dto;
using BusinessLogic.Services;
using BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharactersController(ICharacterService characterService)
        {
            _characterService = characterService;
        }
        [HttpGet] //Get all characters
        public async Task<ActionResult<List<CharactersDto>>> GetAll([FromQuery] CharacterFilterDto characterFilterDto)
        {
            try
            {
                return Ok(await _characterService.GetAll(characterFilterDto));
            }
            catch (Exception ex)
            {
                return BadRequest("Algo salió mal.");
            }
        }
        [HttpGet("{id}")] //Get one character
        public async Task<ActionResult<CharacterDto>> GetCharacter([FromQuery]int id)
        {
            try
            {
                return Ok(await _characterService.GetOne(id));
            }
            catch (Exception ex)
            {
                return BadRequest("Algo salió mal.");
            }
        }
        [HttpPost] //Create character
        public async Task<ActionResult> AddCharacter(CharacterDto characterDto)
        {
            try
            {
                await _characterService.AddCharacter(characterDto);
                return Ok("Creaste un personaje.");
            }
            catch (Exception ex)
            {
                return BadRequest("Algo salió mal.");
            }
        }
        
        [HttpPut] //Update character
        public async Task<ActionResult<CharacterDto>> UpdateCharacter(CharacterDto characterDto,[FromQuery] int id)
        {

            try
            {
                return Ok(await _characterService.UpdateCharacter(characterDto, id));
            }
            catch (Exception ex)
            {
                return BadRequest("Algo salió mal.");
            }
        }
        [HttpDelete]//Delete character
        public async Task<ActionResult> DeleteCharacter([FromQuery]int id)
        {
            try
            {
                await _characterService.DeleteCharacter(id);
                return Ok($"El personaje con id:{id} ha sido eliminado.");
            }
            catch (Exception ex)
            {
                return BadRequest("Algo salió mal.");
            }
        }
    }
}
