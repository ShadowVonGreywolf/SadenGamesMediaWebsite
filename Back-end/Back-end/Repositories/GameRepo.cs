using Back_end.Models;
using Dapper;
using MySqlConnector;

namespace Back_end.Repositories;

public class GameRepo : IGameRepo
{
    
    private readonly IConfiguration _configuration;

    public GameRepo(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<List<Game>> GetAllGamesAsync()
    {
        using var connection = GetConnection();
        var games = await connection.QueryAsync<Game>("SELECT * FROM products , games WHERE id = game_id ");
        return games.ToList();
    }

    public async Task<Game> GetByIdGameAsync(int id)
    {
        using var connection = GetConnection();
        var game = await connection.QueryFirstOrDefaultAsync<Game>("SELECT * FROM products, games WHERE id = game_id AND id = @id", new { id = id });
        return game;
    }

    public async Task<Game> AddGameAsync(Game game)
    {
        using var connection = GetConnection();
        int id =  await connection.ExecuteScalarAsync<int>(
            "INSERT INTO products (title , genre, rating ,description, price, image_path, stock, product_type) " +
            "VALUES (@title , @genre, @rating ,@description, @price, @image_path, @stock, @product_type);" +
            "SELECT LAST_INSERT_ID();",
            game);
        game.game_id = id;
        await connection.ExecuteAsync(
            "INSERT INTO games (game_id, platform, studio) VALUES (@game_id, @platform, @studio)",game);
        return game;
    }

    public async Task UpdateGameAsync(Game game)
    {
        using var connection = GetConnection();
        await connection.ExecuteAsync(
            "UPDATE games " +
            "SET platform = @platform, studio = @studio " +
            "WHERE game_id = @game_id",
            game);
    }

    public async Task DeleteGameAsync(int id)
    {
        using var connection = GetConnection();
        await connection.ExecuteAsync("DELETE FROM games WHERE game_id = @Id" , new {Id = id});
        await connection.ExecuteAsync("DELETE FROM products WHERE id = @Id" , new {Id = id});
    }
    
    private MySqlConnection GetConnection()
    {
        return new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));
    }
    
}