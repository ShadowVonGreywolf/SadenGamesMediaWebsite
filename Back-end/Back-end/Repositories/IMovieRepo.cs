using Back_end.Models;

namespace Back_end.Repositories;

public interface IMovieRepo
{
    Task<List<Movie>> GetAllMoviesAsync();
    Task<Movie> GetByIdMovieAsync(int id);
    Task<Movie> AddMovieAsync(Movie movie);
    Task UpdateMovieAsync(Movie movie);
    Task DeleteMovieAsync(int id);
}