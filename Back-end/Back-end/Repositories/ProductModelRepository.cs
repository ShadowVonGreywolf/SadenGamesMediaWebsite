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

    public async Task<List<ProductModel>> GetAllAsync()
    {
        using var connection = GetConnection();
        var productModels = await connection.QueryAsync<ProductModel>("SELECT * FROM products");
        return productModels.ToList();
    }

    public async Task<ProductModel> GetByIdAsync(int id)
    {
        using var connection = GetConnection();
        var productModel = await connection.QueryFirstOrDefaultAsync<ProductModel>("SELECT * FROM products WHERE ID = @id", new { id = id });
        return productModel;
    }

    public async Task AddAsync(ProductModel productModel)
    {
        using var connection = GetConnection();
        await connection.ExecuteAsync(
            "INSERT INTO products (title , genre, rating ,description, price, image_path, stock, product_type) " +
            "VALUES (@title , @genre, @rating ,@description, @price, @image_path, @stock, @product_type)",
            productModel);
    }

    public async Task UpdateAsync(ProductModel productModel)
    {
        using var connection = GetConnection();
        await connection.ExecuteAsync(
            "UPDATE products " +
            "SET title = @title , genre = @genre , rating = @rating , description = @description, price = @price , image_path = @image_path, stock = @stock, product_type = @product_type " +
            "WHERE id = @id",
            productModel);
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    private MySqlConnection GetConnection()
    {
        return new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));
    }
}
