using Back_end.Models;
using Back_end.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Back_end.Controllers;

[Route("api/[controler]")]
[ApiController]

public class MovieController : ControllerBase
{
    private readonly IMovieRepo _movieRepo;

    public MovieController(IMovieRepo movieRepo)
    {
        _movieRepo = movieRepo;
    }

    [HttpGet]
    public async Task<ActionResult<List<Movie>>> GetAllMoviesAsync()
    {
        var movie = await _movieRepo.GetAllMoviesAsync();
        return Ok(movie);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Movie>> GetByIdMovieAsync(int id)
    {
        var movie = await _movieRepo.GetByIdMovieAsync(id);
        return movie;
    }
    
    [HttpPost]
    public async Task<ActionResult<Movie>> AddMovieAsync([FromBody] Movie movie)
    {
        await _movieRepo.AddMovieAsync(movie);
        return Ok();
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<Movie>> UpdateMovieAsync(int id, Movie movie)
    {
        var exists = await _movieRepo.GetByIdMovieAsync(id);
        if (exists == null)
            return NotFound("Movie not found");
        await _movieRepo.UpdateMovieAsync(movie);
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<Movie>> DeleteMovieAsync(int id)
    {
        var exists = await _movieRepo.GetByIdMovieAsync(id);
        if (exists == null)
            return NotFound("Movie not found");
        await _movieRepo.DeleteMovieAsync(id);
        return Ok();
    }
}