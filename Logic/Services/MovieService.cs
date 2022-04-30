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
        public async Task<List<MoviesDto>> GetAll(MovieFilterDto moviesFilterDto, string order)
        {
            var movie = from m in _context.Movies
                        where (moviesFilterDto.Title == null || m.Title == moviesFilterDto.Title)
                        && (moviesFilterDto.GenreId == 0 || (m.Genres != null
                        && m.Genres.Any(g => g.GenreId == moviesFilterDto.GenreId)))
                        select new MoviesDto { Title = m.Title, Image = m.Image, Release = m.Release };

            switch (order)
            {
                case "ASC":
                    return await movie.OrderBy(movie => movie.Release).ToListAsync();

                case "DESC":
                    return await movie.OrderByDescending(movie => movie.Release).ToListAsync();

                case string when ((order != "ASC") || (order != "DESC") && order != null):
                    throw new ArgumentException("Solo se pueden usar las palabras clave: 'ASC' o 'DESC'.");

                default:
                    return await movie.ToListAsync();
            }
        }
        public async Task<MovieDto> GetMovie(int id)
        {
            var movie = await _context.Movies.Include(x => x.Characters)
                .Include(z => z.Genres)
                .FirstOrDefaultAsync(x => x.MovieId == id);

            if (movie == null)
                throw new KeyNotFoundException("La película con ese id no existe.");

            return _mapper.Map<MovieDto>(movie);
        }
        public async Task AddMovie(NewMovieDto movieDto)
        {
            var movie = _mapper.Map<Movie>(movieDto);
            if (movieDto.CharacterId != null)
            {
                foreach (var c in movieDto.CharacterId)
                {
                    var character = await _context.Characters.FindAsync(c);
                    if (character != null)
                    {
                        movie.Characters.Add(character);
                    }
                    else
                    {
                        throw new KeyNotFoundException("El id del personaje no existe.");
                    }
                }
            }
            if (movieDto.GenreId != null)
            {
                foreach (var g in movieDto.GenreId)
                {
                    var genre = await _context.Genres.FindAsync(g);
                    if (genre != null)
                    {
                        movie.Genres.Add(genre);
                    }
                    else
                    {
                        throw new KeyNotFoundException("El id del género no existe.");
                    }
                }
            }

            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMovie(UpdateMovieDto movieDto)
        {
            var movieExists = await _context.Movies
                          .AnyAsync(x => x.MovieId == movieDto.MovieId);
            if (movieExists)
            {
                var movie = _mapper.Map<Movie>(movieDto);
                _context.Movies.Update(movie);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("La película con el id ingresado no existe.");
            }
        }
        public async Task DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie != null)
            {
                _context.Movies.Remove(movie);
            }
            else
            {
                throw new KeyNotFoundException("La película con el id ingresado no existe.");
            }
            await _context.SaveChangesAsync();
        }
        public async Task<List<GenreDto>> GetGenre()
        {
            var genre = await _context.Genres.ToListAsync();
            return _mapper.Map<List<GenreDto>>(genre);
        }
    }
}
