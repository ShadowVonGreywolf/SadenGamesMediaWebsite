using Back_end.Models;

namespace Back_end.Repositories;

public interface IGameRepo
{ 
    Task<List<Game>> GetAllGamesAsync();
    Task<Game> GetByIdGameAsync(int id);
    Task<Game> AddGameAsync(Game game);
    Task UpdateGameAsync(Game game);
    Task DeleteGameAsync(int id);
}