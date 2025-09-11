using Back_end.Models;

namespace Back_end.Repositories;

public interface IMovieModelRepository
{
    Task AddMovieAsync(MovieModel movieModel, int id);
    Task UpdateMovieAsync(MovieModel movieModel);
    Task DeleteMovieAsync(int id);
}