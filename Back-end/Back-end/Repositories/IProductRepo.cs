using Back_end.Models;

namespace Back_end.Repositories;

public interface IProductRepo
{
    Task<List<Product>> GetAllProductsAsync();
    Task<Product> GetByIdProductAsync(int id);
    Task<int> AddProductAsync(Product product);
    Task UpdateProductAsync(Product product);
    Task DeleteProductAsync(int id);
   

}