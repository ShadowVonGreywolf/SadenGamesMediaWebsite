using Back_end.Models;
using Dapper;
using MySqlConnector;

namespace Back_end.Repositories;

public class MovieRepo : IMovieRepo
{
    private readonly IConfiguration _configuration;

    public MovieRepo(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<List<Movie>> GetAllMoviesAsync()
    {
        using var connection = GetConnection();
        var movies = await connection.QueryAsync<Movie>("SELECT * FROM products , movies WHERE id = movie_id ");
        return movies.ToList();
    }

    public async Task<Movie> GetByIdMovieAsync(int id)
    {
        using var connection = GetConnection();
        var movie = await connection.QueryFirstOrDefaultAsync<Movie>("SELECT * FROM products, movies WHERE id = movies_id AND id = @id", new { id = id });
        return movie;
    }

    public async Task<Movie> AddMovieAsync(Movie movie)
    {
        using var connection = GetConnection();
        int id =  await connection.ExecuteScalarAsync<int>(
            "INSERT INTO products (title , genre, rating ,description, price, image_path, stock, product_type) " +
            "VALUES (@title , @genre, @rating ,@description, @price, @image_path, @stock, @product_type);" +
            "SELECT LAST_INSERT_ID();",
            movie);
        movie.movie_id = id;
        await connection.ExecuteAsync(
            "INSERT INTO movies (movie_id, director, duration) VALUES (@movie_id, @director, @duration)",movie);
        return movie;
    }

    public async Task UpdateMovieAsync(Movie movie)
    {
        using var connection = GetConnection();
        await connection.ExecuteAsync(
            "UPDATE movies " +
            "SET director = @director, duration = @duration " +
            "WHERE movie_id = @movie_id",
            movie);
    }

    public async Task DeleteMovieAsync(int id)
    {
        using var connection = GetConnection();
        await connection.ExecuteAsync("DELETE FROM movies WHERE movie_id = @Id" , new {Id = id});
        await connection.ExecuteAsync("DELETE FROM products WHERE id = @Id" , new {Id = id});
    }
    
    private MySqlConnection GetConnection()
    {
        return new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));
    }
}