using BusinessLogic.Dto;
using BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharactersController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet] //Get all characters
        public async Task<ActionResult> GetAll([FromQuery] CharacterFilterDto characterFilterDto)
        {
            try
            {
                return Ok(await _characterService.GetAll(characterFilterDto));
            }
            catch
            {
                return BadRequest("Algo salió mal.");
            }
        }

        [HttpGet("{id}")] //Get one character
        public async Task<ActionResult> GetCharacter(int id)
        {
            try
            {
                return Ok(await _characterService.GetCharacter(id));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch
            {
                return BadRequest("Algo salió mal.");
            }
        }

        [HttpPost] //Create character
        public async Task<ActionResult> AddCharacter(NewCharacterDto characterDto)
        {
            try
            {
                await _characterService.AddCharacter(characterDto);
                return Ok("Creaste un personaje.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch
            {
                return BadRequest("Algo salió mal.");
            }
        }

        [HttpPut] //Update character
        public async Task<ActionResult> UpdateCharacter(UpdateCharacterDto characterDto)
        {
            try
            {
                await _characterService.UpdateCharacter(characterDto);
                return Ok("Personaje actualizado con éxito.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch
            {
                return BadRequest("Algo salió mal.");
            }
        }

        [HttpDelete]//Delete character
        public async Task<ActionResult> DeleteCharacter([FromQuery] int id)
        {
            try
            {
                await _characterService.DeleteCharacter(id);
                return Ok($"El personaje con id:{id} ha sido eliminado.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch
            {
                return BadRequest("Algo salió mal.");
            }
        }

        [HttpPost("{characterId}/Movie")]//Create Relationship
        public async Task<ActionResult> AddRelationship(int characterId, int movieId)
        {
            try
            {
                await _characterService.AddRelationship(characterId, movieId);
                return Ok("La relación fue creada con éxito.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch
            {
                return BadRequest("Algo salió mal.");
            }
        }

        [HttpDelete("{characterId}/Movie")]//Delete Relationship
        public async Task<ActionResult> DeleteRelationship(int characterId, int movieId)
        {
            try
            {
                await _characterService.DeleteRelationship(characterId, movieId);
                return Ok("La relación fue eliminada con éxito.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch
            {
                return BadRequest("Algo salió mal.");
            }
        }
    }
}
