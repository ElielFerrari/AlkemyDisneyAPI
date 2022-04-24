using BusinessLogic.Dto;
using BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        [HttpGet] //Get all movies
        public async Task<ActionResult<List<MoviesDto>>> GetAll([FromQuery]MovieFilterDto moviesFilterDto)
        {
            try
            {
                return Ok (await _movieService.GetAll(moviesFilterDto));
            }
            catch (Exception ex)
            {
                return BadRequest("Algo salió mal.");
            }
        }
        public async Task<ActionResult> AddMovie(MovieDto movieDto)
        {
            try
            {
                await _movieService.AddMovie(movieDto);
                return Ok("Creaste una película con éxito.");
            }
            catch
            {
                return BadRequest("Algo salió mal.");
            }
        }
    }

}
