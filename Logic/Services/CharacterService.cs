using AutoMapper;
using BusinessLogic.Dto;
using BusinessLogic.Services.Interfaces;
using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
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
                            && (characterFilterDto.MovieId == 0 || (c.Movies != null
                            && c.Movies.Any(m => m.MovieId == characterFilterDto.MovieId)))
                            select new CharactersDto { Name = c.Name, Image = c.Image };

            return await character.ToListAsync();
        }
        public async Task<CharacterDto> GetOne(int id)
        {
            var character = await _context.Characters.FindAsync(id);
            
            return _mapper.Map<CharacterDto>(character);

        }
        public async Task AddCharacter(CharacterDto characterDto)
        {
            var character = _mapper.Map<Character>(characterDto);

            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
        }
        public async Task<CharacterDto> UpdateCharacter(CharacterDto characterDto, int id)
        {
            var characterId = await _context.Characters.FindAsync(id);

            characterId.Name = characterDto.Name;
            characterId.Age = characterDto.Age;
            characterId.Image = characterDto.Image;
            characterId.Weight = characterDto.Weight;
            characterId.Story = characterDto.Story;
            characterId.Movies = characterDto.Movies;

            await _context.SaveChangesAsync();

            return _mapper.Map<CharacterDto>(characterId);
        }
        public async Task DeleteCharacter(int id)
        {
            var character = await _context.Characters.FindAsync(id);

            if (character != null)
                _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
        }
    }
}
