using AutoMapper;
using BusinessLogic.Dto;
using BusinessLogic.Services.Interfaces;
using DataAccess;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CharacterService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<CharactersDto>> GetAll(CharacterFilterDto characterFilterDto)
        {
            var character = from c in _context.Characters
                            where (characterFilterDto.Name == null || c.Name == characterFilterDto.Name)
                            && (characterFilterDto.Age == 0 || c.Age == characterFilterDto.Age)
                            && (characterFilterDto.MovieId == 0 || c.Movies
                            .Where(x => x.MovieId == characterFilterDto.MovieId).Any())
                            select new CharactersDto { Name = c.Name, Image = c.Image };

            return await character.ToListAsync();
        }
        public async Task<CharacterDto> GetCharacter(int id)
        {
            var character = await _context.Characters.Include(x => x.Movies)
                .FirstOrDefaultAsync(x => x.CharacterId == id);
            if (character == null)
                throw new KeyNotFoundException("El personaje con ese id no existe.");

            return _mapper.Map<CharacterDto>(character);

        }
        public async Task AddCharacter(NewCharacterDto characterDto)
        {
            var character = _mapper.Map<Character>(characterDto);
            if (characterDto.MovieId != null)
            {
                foreach (var m in characterDto.MovieId)
                {
                    var movie = await _context.Movies.FindAsync(m);
                    if (movie != null)
                    {
                        character.Movies.Add(movie);
                    }
                    else
                    {
                        throw new KeyNotFoundException("El id de la película no existe.");
                    }
                }
            }
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateCharacter(UpdateCharacterDto characterDto)
        {
            var characterExists = await _context.Characters
                                  .AnyAsync(x => x.CharacterId == characterDto.CharacterId);

            if (characterExists)
            {
                var character = _mapper.Map<Character>(characterDto);
                _context.Characters.Update(character);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("El personaje con el id ingresado no existe.");
            }

        }
        public async Task DeleteCharacter(int id)
        {
            var character = await _context.Characters.FindAsync(id);

            if (character != null)
            {
                _context.Characters.Remove(character);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("El personaje con el id ingresado no existe.");
            }
        }
        public async Task AddRelationship(int characterId, int movieId)
        {
            var character = await _context.Characters
                            .FirstOrDefaultAsync(x => x.CharacterId == characterId
                            && !x.Movies.Any(c => c.MovieId == movieId));

            var movie = await _context.Movies.FindAsync(movieId);

            if ((character != null) && (movie != null))
            {
                character.Movies.Add(movie);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("El id del personaje o la película no existe o está repetido uno de los id.");
            }
        }
        public async Task DeleteRelationship(int characterId, int movieId)
        {
            var character = await _context.Characters
                            .Include(x => x.Movies)
                            .FirstOrDefaultAsync(x => x.CharacterId == characterId
                            && x.Movies.Any(c => c.MovieId == movieId));

            var movie = await _context.Movies.FindAsync(movieId);

            if ((character != null) && (movie != null))
            {
                character.Movies.Remove(movie);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("El id del personaje o la película no existe o no están relacionados.");
            }
        }
    }
}
