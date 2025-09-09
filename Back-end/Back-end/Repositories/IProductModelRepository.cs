using Back_end.Models;

namespace Back_end.Repositories;

public interface IProductModelRepository
{
    Task<List<ProductModel>> GetAllAsync();
    Task<ProductModel> GetByIdAsync(int id);
    Task AddAsync(ProductModel productModel);
    Task UpdateAsync(ProductModel productModel);
    Task DeleteAsync(int id);

}