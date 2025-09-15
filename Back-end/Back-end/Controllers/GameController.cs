using Back_end.Models;
using Back_end.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Back_end.Controllers;

[Route("api/[controller]")]
[ApiController]

public class GameController : ControllerBase
{
    private readonly IGameRepo _gameRepo;

    public GameController(IGameRepo gameRepo)
    {
        _gameRepo = gameRepo;
    }

    [HttpGet]
    public async Task<ActionResult<List<Game>>> GetAllGamesAsync()
    {
        var game = await _gameRepo.GetAllGamesAsync();
        return Ok(game);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Game>> GetByIdGameAsync(int id)
    {
        var game = await _gameRepo.GetByIdGameAsync(id);
        return game;
    }

    [HttpPost]
    public async Task<ActionResult<Game>> AddGameAsync([FromBody] Game game)
    {
        await _gameRepo.AddGameAsync(game);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Game>> UpdateGameAsync(int id, Game game)
    {
        var exists = await _gameRepo.GetByIdGameAsync(id);
        if (exists == null)
            return NotFound("Game not found");
        await _gameRepo.UpdateGameAsync(game);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Game>> DeleteGameAsync(int id)
    {
        var exists = await _gameRepo.GetByIdGameAsync(id);
        if (exists == null)
            return NotFound("Game not found");
        await _gameRepo.DeleteGameAsync(id);
        return Ok();
    }

}