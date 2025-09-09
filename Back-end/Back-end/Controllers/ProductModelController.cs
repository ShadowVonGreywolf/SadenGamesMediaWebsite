using Back_end.Models;
using Back_end.Repositories;
using Microsoft.AspNetCore.Http;
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
    public async Task<ActionResult<List<ProductModel>>> GetAllAsync()
    {
        var productModel = await _productModelRepository.GetAllAsync();
        return Ok(productModel);
    }

    [HttpGet("{id}")]

    public async Task<ActionResult<ProductModel>> GetByIdAsync(int id)
    {
        var productModel = await _productModelRepository.GetByIdAsync(id);
        return productModel;
    }

    [HttpPost]
    public async Task<ActionResult<ProductModel>> AddAsync(ProductModel productModel)
    {
        await _productModelRepository.AddAsync(productModel);
        return Ok();
    }

    [HttpPut]
    public async Task<ActionResult<ProductModel>> UpdateAsync(ProductModel productModel)
    {
        await _productModelRepository.UpdateAsync(productModel);
        return Ok();
    }
}