using backend_keystore.Models.Receipts;

namespace backend_keystore.Models.Products;

public class Product
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = "test";
    public long Ean { get; set; } 
    public double Price { get; set; } 
    
   
}