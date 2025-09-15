using Back_end.Models;
using Back_end.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Back_end.Controllers;

[Route ("api/[controller]")]
[ApiController]

public class ProductController : ControllerBase
{
    private readonly IProductRepo _productRepo;

    public ProductController(IProductRepo productRepo)
    {
        _productRepo = productRepo;
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetAllProductsAsync()
    {
        var productModel = await _productRepo.GetAllProductsAsync();
        return Ok(productModel);
    }

    [HttpGet("{id}")]

    public async Task<ActionResult<Product>> GetByIdProductAsync(int id)
    {
        var productModel = await _productRepo.GetByIdProductAsync(id);
        return productModel;
    }

    [HttpPost]
    public async Task<ActionResult<Product>> AddProductAsync(Product product)
    {
        int id = await _productRepo.AddProductAsync(product);
        Console.WriteLine("This is the last id " + id);//testing the returned id
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Product>> UpdateProductAsync(int id, Product product)
    {
        var exists = await _productRepo.GetByIdProductAsync(id);
        if (exists == null)
            return NotFound("Product not found");
        await _productRepo.UpdateProductAsync(product);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Product>> DeleteProductAsync(int id)
    {
        var exists = await _productRepo.GetByIdProductAsync(id);
        if (exists == null)
            return NotFound("Product not found");
        await _productRepo.DeleteProductAsync(id);
        return Ok();
    }
}