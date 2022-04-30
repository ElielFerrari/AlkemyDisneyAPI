using BusinessLogic.Dto;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLogic.Services.Interfaces
{
    public interface ICharacterService
    {
        Task AddCharacter(NewCharacterDto characterDto);
        Task DeleteCharacter(int id);
        Task<List<CharactersDto>> GetAll(CharacterFilterDto characterFilterDto);
        Task<CharacterDto> GetCharacter(int id);
        Task UpdateCharacter(UpdateCharacterDto characterDto);
        Task AddRelationship(int characterId, int movieId);
        Task DeleteRelationship(int characterId, int movieId);
    }
}