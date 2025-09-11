using Back_end.Models;
using Dapper;
using MySqlConnector;

namespace Back_end.Repositories;

public class GameModelRepository : IGameModelRepository
{
    private readonly IConfiguration _configuration;
    
    public GameModelRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public async Task AddGameAsync(GameModel gameModel, int id)
    {
        using var connection = GetConnection();
        await connection.ExecuteAsync("INSERT INTO games (game_id, platform, studio)" +
                                      "VALUES (@Id , @Platform, @Studio);",
            new { Id = id, Platform = gameModel.platform, Studio = gameModel.studio });
    }

    public async Task UpdateGameAsync(GameModel gameModel)
    {
        using var connection = GetConnection();
        await connection.ExecuteAsync(
            "UPDATE games " +
            "SET platform = @platform , studio = @studio" + 
            "WHERE game_id = @game_id",
            gameModel);
    }

    public async Task DeleteGameAsync(int id)
    {
        using var connection = GetConnection();
        await connection.ExecuteAsync("DELETE FROM games WHERE game_id = @game_id" , new {game_id = id});
    }
    
    private MySqlConnection GetConnection()
    {
        return new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));
    }
}