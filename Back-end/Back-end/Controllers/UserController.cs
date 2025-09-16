using Back_end.Models;
using Back_end.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Back_end.Controllers;

[Route("api/[controller]")]
[ApiController]

public class UserController : ControllerBase
{
    private readonly IUserRepo _userRepo;

    public UserController(IUserRepo userRepo)
    {
        _userRepo = userRepo;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<User>>> GetAllUsersAsync()
    {
        var user = await _userRepo.GetAllUsersAsync();
        return Ok(user);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetByIdUserAsync(int id)
    {
        var user = await _userRepo.GetByIdUserAsync(id);
        return user;
    }
    
    [HttpPost]
    public async Task<ActionResult<User>> AddUserAsync([FromBody] User user)
    {
        await _userRepo.AddUserAsync(user);
        return Ok();
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<User>> UpdateUserAsync(int id, User user)
    {
        var exists = await _userRepo.GetByIdUserAsync(id);
        if (exists == null)
            return NotFound("User not found");
        await _userRepo.UpdateUserAsync(user);
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<User>> DeleteUserAsync(int id)
    {
        var exists = await _userRepo.GetByIdUserAsync(id);
        if (exists == null)
            return NotFound("User not found");
        await _userRepo.DeleteUserAsync(id);
        return Ok();
    }
}