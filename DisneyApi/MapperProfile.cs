using AutoMapper;
using BusinessLogic.Dto;
using DataAccess.Models;

namespace DisneyApi
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            //Character
            CreateMap<CharacterDto, Character>();
            CreateMap<Character, CharacterDto>();
            CreateMap<CharactersDto, Character>();
            CreateMap<Character, CharactersDto>();
            //Movie
            CreateMap<MovieDto, Movie>();
            CreateMap<Movie, MovieDto>();
            CreateMap<MoviesDto, MovieDto>();
            CreateMap<Movie, MoviesDto>();
        }
    }
}
