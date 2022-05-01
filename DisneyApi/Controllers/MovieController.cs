using BusinessLogic.Dto;
using BusinessLogic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet] //Get all movies
        public async Task<ActionResult> GetAll([FromQuery] MovieFilterDto moviesFilterDto)
        {
            try
            {
                return Ok(await _movieService.GetAll(moviesFilterDto));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return BadRequest("Algo salió mal.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetMovie(int id)
        {
            try
            {
                return Ok(await _movieService.GetMovie(id));
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

        [HttpPost]//Create Movie
        public async Task<ActionResult> AddMovie(NewMovieDto movieDto)
        {
            try
            {
                await _movieService.AddMovie(movieDto);
                return Ok("Creaste una película con éxito.");
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
        [HttpPut]//Update Movie
        public async Task<ActionResult> UpdateMovie(UpdateMovieDto movieDto)
        {
            try
            {
                await _movieService.UpdateMovie(movieDto);
                return Ok("El personaje fue creado con éxito");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch
            {
                return BadRequest("Algo salió mal");
            }
        }

        [HttpDelete]//Delete Movie
        public async Task<ActionResult> DeleteMovie(int id)
        {
            try
            {
                await _movieService.DeleteMovie(id);
                return Ok($"La película con id:{id} ha sido eliminada.");
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

        [HttpGet("Genres")]
        public async Task<ActionResult> GetGenre()
        {
            try
            {
                return Ok(await _movieService.GetGenre());
            }
            catch
            {
                return BadRequest("Algo salió mal.");
            }
        }
    }
}
