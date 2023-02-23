using backend_keystore.Models;
using backend_keystore.Models.Products;

namespace backend_keystore.Services.ProductServices;

public interface IProductService
{
    Task<ServiceResponse<List<Product>>> GetAllProducts();
    Task<ServiceResponse<Product>> AddProduct(Product newProduct);
}