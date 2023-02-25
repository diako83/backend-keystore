using backend_keystore.Data;
using backend_keystore.Dto;
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

    public async Task<ServiceResponse<List<ProductDto>>> GetAllProducts()
    {
        var serviceResponse = new ServiceResponse<List<ProductDto>>();
        serviceResponse.Data =  _context.Product.Select(p=>new ProductDto(p.Id,p.Name,p.Ean,p.Price)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<ProductDto>> AddProduct(ProductDto newProduct)
    {
        var serviceResponse = new ServiceResponse<ProductDto>();

        if ( _context.Product.
            Any(c => c.Id == newProduct.Id))
        {
            serviceResponse.Message = $"Product with id {newProduct.Id} alredy exists ";
            serviceResponse.Success = false;
        }
        else
        {
            Product prod = new Product
            {
                Id = newProduct.Id,
                Name = newProduct.Name,
                Ean = newProduct.Ean,
                Price = newProduct.Price,
                
            };
            _context.Product.Add(prod);
            await _context.SaveChangesAsync();

           bool product = await _context.Product.AnyAsync(c => c.Id == newProduct.Id);
           if (!product)
           {
               serviceResponse.Message = $"Product with id {newProduct.Id} did not save  ";
               serviceResponse.Success = false;
           }
           else
           {
               serviceResponse.Data = newProduct;      
               serviceResponse.Message = "Product has been added";         
           }
        }
        
       return serviceResponse;
    }
}