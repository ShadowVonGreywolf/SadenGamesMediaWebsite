using Back_end.Models;

namespace Back_end.Repositories;

public interface IProductModelRepository
{
    Task<List<ProductModel>> GetAllProductsAsync();
    Task<ProductModel> GetByIdProductAsync(int id);
    Task<int> AddProductAsync(ProductModel productModel);
    Task UpdateProductAsync(ProductModel productModel);
    Task DeleteProductAsync(int id);
   

}