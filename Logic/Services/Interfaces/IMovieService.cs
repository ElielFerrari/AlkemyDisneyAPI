using BusinessLogic.Dto;

namespace BusinessLogic.Services
{
    public interface IMovieService
    {
        Task AddMovie(NewMovieDto movieDto);
        Task DeleteMovie(int id);
        Task<List<MoviesDto>> GetAll(MovieFilterDto moviesFilterDto);
        Task<List<GenreDto>> GetGenre();
        Task<MovieDto> GetMovie(int id);
        Task UpdateMovie(UpdateMovieDto movieDto);
    }
}