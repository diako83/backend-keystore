using backend_keystore.Data;
using backend_keystore.Models;
using backend_keystore.Models.Products;
using Microsoft.EntityFrameworkCore;
using static System.Guid;

namespace backend_keystore.Services.ProductServices;

public class ProductService:IProductService
{
    private readonly DataContext _context;


    public ProductService(DataContext context)
    {
        _context = context;
    }

    public async Task<ServiceResponse<List<Product>>> GetAllProducts()
    {
        var serviceResponse = new ServiceResponse<List<Product>>();
        serviceResponse.Data =  _context.Product.ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<Product>> AddProduct(Product newProduct)
    {
        var serviceResponse = new ServiceResponse<Product>();

        if ( _context.Product.
            Any(c => c.Id == newProduct.Id))
        {
            serviceResponse.Message = $"Product with id {newProduct.Id} alredy exists ";
            serviceResponse.Success = false;
        }
        else
        {
            _context.Product.Add(newProduct);
            await _context.SaveChangesAsync();

            var product = await _context.Product.FirstOrDefaultAsync(c => c.Id == newProduct.Id);
            serviceResponse.Data = product;      
            serviceResponse.Message = "Product has been added";      
        }
        
       return serviceResponse;
    }
}