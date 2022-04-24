using BusinessLogic.Dto;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLogic.Services.Interfaces
{
    public interface ICharacterService
    {
        Task AddCharacter(CharacterDto characterDto);
        Task DeleteCharacter(int id);
        Task<List<CharactersDto>> GetAll(CharacterFilterDto characterFilterDto);
        Task<CharacterDto> GetOne(int id);
        Task<CharacterDto> UpdateCharacter(CharacterDto characterDto, int id);
    }
}