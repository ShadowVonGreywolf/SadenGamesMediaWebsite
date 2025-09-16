using Back_end.Models;
using Dapper;
using MySqlConnector;

namespace Back_end.Repositories;

public class UserRepo : IUserRepo
{
    private readonly IConfiguration _configuration;

    public UserRepo(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        using var connection = GetConnection();
        var users = await connection.QueryAsync<User>("SELECT * FROM users ;");
        return users.ToList();
    }

    public async Task<User> GetByIdUserAsync(int id)
    {
        using var connection = GetConnection();
        var user = await connection.QueryFirstOrDefaultAsync<User>("SELECT * FROM users WHERE user_id = @id", new { id = id });
        return user;
    }

    public async Task<User> AddUserAsync(User user)
    {
        using var connection = GetConnection();
        await connection.ExecuteAsync(
            "INSERT INTO users (username, email, password, role, image_path) " +
            "VALUES (@username , @email, @password ,@role, @price, @image_path);",
            user);
        return user;
    }

    public async Task UpdateUserAsync(User user)
    {
        using var connection = GetConnection();
        await connection.ExecuteAsync(
            "UPDATE users " +
            "SET username = @username , email = @email , password = @password , role = @role, price = @price , image_path = @image_path " +
            "WHERE user_id = @user_id",
            user);
    }

    public async Task DeleteUserAsync(int id)
    {
        using var connection = GetConnection();
        await connection.ExecuteAsync("DELETE FROM users WHERE user_id = @Id" , new {Id = id});
    }
    
    private MySqlConnection GetConnection()
    {
        return new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));
    }
}