using Back_end.Models;
using Dapper;
using MySqlConnector;

namespace Back_end.Repositories;

public class ProductModelRepository : IProductModelRepository
{
    private readonly IConfiguration _configuration;

    public ProductModelRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<List<ProductModel>> GetAllProductsAsync()
    {
        using var connection = GetConnection();
        var productModels = await connection.QueryAsync<ProductModel>("SELECT * FROM products");
        return productModels.ToList();
    }

    public async Task<ProductModel> GetByIdProductAsync(int id)
    {
        using var connection = GetConnection();
        var productModel = await connection.QueryFirstOrDefaultAsync<ProductModel>("SELECT * FROM products WHERE ID = @id", new { id = id });
        return productModel;
    }

    public async Task<int> AddProductAsync(ProductModel productModel)
    {
        using var connection = GetConnection();
        return await connection.QuerySingleAsync<int>(
            "INSERT INTO products (title , genre, rating ,description, price, image_path, stock, product_type) " +
            "VALUES (@title , @genre, @rating ,@description, @price, @image_path, @stock, @product_type);" +
            "SELECT LAST_INSERT_ID();",
            productModel);
    }

    public async Task UpdateProductAsync(ProductModel productModel)
    {
        using var connection = GetConnection();
        await connection.ExecuteAsync(
            "UPDATE products " +
            "SET title = @title , genre = @genre , rating = @rating , description = @description, price = @price , image_path = @image_path, stock = @stock, product_type = @product_type " +
            "WHERE id = @id",
            productModel);
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
