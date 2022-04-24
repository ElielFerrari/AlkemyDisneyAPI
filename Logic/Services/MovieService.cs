using AutoMapper;
using BusinessLogic.Dto;
using DataAccess;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class MovieService : IMovieService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public MovieService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<MoviesDto>> GetAll(MovieFilterDto moviesFilterDto)
        {
            var movie = from m in _context.Movies
                        where (moviesFilterDto.Title == null || m.Title == moviesFilterDto.Title)
                        && (moviesFilterDto.GenreId == 0 || (m.Genres != null
                        && m.Genres.Any(g => g.GenreID == moviesFilterDto.GenreId)))
                        /*&& (release == null || m.Release != null)              
                        orderby m.Release where (release == "ASC" || release == "DESC")*/
                        select new MoviesDto { Title = m.Title, Image = m.Image, Release = m.Release };

            return await movie.ToListAsync();
        }
        public async Task AddMovie(MovieDto movieDto)
        {
            var movie = _mapper.Map<Movie>(movieDto);

            _context.Movies.Add(movie);
            await _context.SaveChangesAsync(); 
        }
    }
}
