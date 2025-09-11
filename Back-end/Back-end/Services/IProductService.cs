using Back_end.Models;

namespace Back_end.Services;

public interface IProductService
{
    Task<int> AddGameAsync(ProductModel product, GameModel game);
    Task<int> AddMovieAsync(ProductModel product, MovieModel movie);
    Task<ProductModel?> GetProductWithDetailsAsync(int id);
}