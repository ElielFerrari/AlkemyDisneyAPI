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
            CreateMap<CharacterDto, Character>().ReverseMap();
            CreateMap<CharactersDto, Character>().ReverseMap();
            CreateMap<Character, NewCharacterDto>().ReverseMap();
            CreateMap<Character, UpdateCharacterDto>().ReverseMap();
            //Movie
            CreateMap<Movie, MovieDto>().ReverseMap();
            CreateMap<Movie, MoviesDto>().ReverseMap();
            CreateMap<MoviesDto, MovieDto>().ReverseMap();
            CreateMap<Movie, NewMovieDto>().ReverseMap();
            CreateMap<Movie, UpdateMovieDto>().ReverseMap();
            CreateMap<Genre, GenreDto>().ReverseMap();

            //User
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
