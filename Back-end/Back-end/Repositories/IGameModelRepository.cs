using Back_end.Models;

namespace Back_end.Repositories;

public interface IGameModelRepository
{
    Task AddGameAsync(GameModel gameModel, int id);
    Task UpdateGameAsync(GameModel gameModel);
    Task DeleteGameAsync(int id);
}