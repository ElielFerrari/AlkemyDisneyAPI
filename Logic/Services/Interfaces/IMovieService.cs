using BusinessLogic.Dto;

namespace BusinessLogic.Services
{
    public interface IMovieService
    {
        Task AddMovie(MovieDto movieDto);
        Task<List<MoviesDto>> GetAll(MovieFilterDto moviesFilterDto);
    }
}