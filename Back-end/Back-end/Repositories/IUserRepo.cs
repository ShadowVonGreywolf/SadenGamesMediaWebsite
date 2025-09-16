using Back_end.Models;

namespace Back_end.Repositories;

public interface IUserRepo
{
    Task<List<User>> GetAllUsersAsync();
    Task<User> GetByIdUserAsync(int id);
    Task<User> AddUserAsync(User user);
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(int id);
}