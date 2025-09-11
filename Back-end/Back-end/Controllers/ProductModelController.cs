using Back_end.Models;
using Back_end.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Back_end.Controllers;

[Route ("api/[controller]")]
[ApiController]

public class ProductModelController : ControllerBase
{
    private readonly IProductModelRepository _productModelRepository;

    public ProductModelController(IProductModelRepository productModelRepository)
    {
        _productModelRepository = productModelRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<ProductModel>>> GetAllProductsAsync()
    {
        var productModel = await _productModelRepository.GetAllProductsAsync();
        return Ok(productModel);
    }

    [HttpGet("{id}")]

    public async Task<ActionResult<ProductModel>> GetByIdProductAsync(int id)
    {
        var productModel = await _productModelRepository.GetByIdProductAsync(id);
        return productModel;
    }

    [HttpPost]
    public async Task<ActionResult<ProductModel>> AddProductAsync(ProductModel productModel)
    {
        int id = await _productModelRepository.AddProductAsync(productModel);
        Console.WriteLine("This is the last id " + id);//testing the returned id
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ProductModel>> UpdateProductAsync(int id, ProductModel productModel)
    {
        var exists = await _productModelRepository.GetByIdProductAsync(id);
        if (exists == null)
            return NotFound("Product not found");
        await _productModelRepository.UpdateProductAsync(productModel);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ProductModel>> DeleteProductAsync(int id)
    {
        var exists = await _productModelRepository.GetByIdProductAsync(id);
        if (exists == null)
            return NotFound("Product not found");
        await _productModelRepository.DeleteProductAsync(id);
        return Ok();
    }
}