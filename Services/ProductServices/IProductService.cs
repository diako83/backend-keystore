using backend_keystore.Dto;
using backend_keystore.Models;
using backend_keystore.Models.Products;

namespace backend_keystore.Services.ProductServices;

public interface IProductService
{
    Task<ServiceResponse<List<ProductDto>>> GetAllProducts();
    Task<ServiceResponse<ProductDto>> AddProduct(ProductDto newProduct);
}