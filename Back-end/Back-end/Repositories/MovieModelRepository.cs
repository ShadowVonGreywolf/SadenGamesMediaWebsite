using Back_end.Models;
using Dapper;
using MySqlConnector;

namespace Back_end.Repositories;

public class MovieModelRepository : IMovieModelRepository
{
    private readonly IConfiguration _configuration;

    public MovieModelRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task AddMovieAsync(MovieModel movieModel, int id)
    {
        using var connection = GetConnection();
        await connection.ExecuteAsync("INSERT INTO movies (movie_id, director, duration)" +
                                      "VALUES (@Id , @Director, @Duration);",
            new { Id = id, Director = movieModel.director, Duration = movieModel.duration });
    }

    public async Task UpdateMovieAsync(MovieModel movieModel)
    {
        using var connection = GetConnection();
        await connection.ExecuteAsync(
            "UPDATE movies " +
            "SET director = @director , duration = @duration" + 
            "WHERE movie_id = @movie_id",
            movieModel);
    }

    public async Task DeleteMovieAsync(int id)
    {
        using var connection = GetConnection();
        await connection.ExecuteAsync("DELETE FROM movies WHERE movie_id = @movie_id" , new {movie_id = id});
    }
    
    private MySqlConnection GetConnection()
    {
        return new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));
    }
}