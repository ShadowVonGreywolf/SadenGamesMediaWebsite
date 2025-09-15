using Back_end.Models;
using Dapper;
using MySqlConnector;

namespace Back_end.Repositories;

public class ProductRepo : IProductRepo
{
    private readonly IConfiguration _configuration;

    public ProductRepo(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<List<Product>> GetAllProductsAsync()
    {
        using var connection = GetConnection();
        var productModels = await connection.QueryAsync<Product>("SELECT * FROM products");
        return productModels.ToList();
    }

    public async Task<Product> GetByIdProductAsync(int id)
    {
        using var connection = GetConnection();
        var productModel = await connection.QueryFirstOrDefaultAsync<Product>("SELECT * FROM products WHERE ID = @id", new { id = id });
        return productModel;
    }

    public async Task<int> AddProductAsync(Product product)
    {
        using var connection = GetConnection();
        return await connection.QuerySingleAsync<int>(
            "INSERT INTO products (title , genre, rating ,description, price, image_path, stock, product_type) " +
            "VALUES (@title , @genre, @rating ,@description, @price, @image_path, @stock, @product_type);" +
            "SELECT LAST_INSERT_ID();",
            product);
    }

    public async Task UpdateProductAsync(Product product)
    {
        using var connection = GetConnection();
        await connection.ExecuteAsync(
            "UPDATE products " +
            "SET title = @title , genre = @genre , rating = @rating , description = @description, price = @price , image_path = @image_path, stock = @stock, product_type = @product_type " +
            "WHERE id = @id",
            product);
    }

    public async Task DeleteProductAsync(int id)
    {
        using var connection = GetConnection();
        await connection.ExecuteAsync("DELETE FROM products WHERE ID = @Id" , new {Id = id});
    }
    
    private MySqlConnection GetConnection()
    {
        return new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));
    }
}
