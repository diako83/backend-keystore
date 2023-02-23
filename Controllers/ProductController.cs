using backend_keystore.Models;
using backend_keystore.Models.Products;
using backend_keystore.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace backend_keystore.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProductController:ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("products")]
    public async Task<ActionResult<ServiceResponse<List<Product>>>> GetAllProducts()
    {
        
        return Ok(await _productService.GetAllProducts());
    }
    
    [HttpPost("products")]
    public async Task<ActionResult<ServiceResponse<List<Product>>>> NewProduct(Product newProduct)
    {
        
        return Ok(await _productService.AddProduct(newProduct));
    }
}