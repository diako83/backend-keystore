using backend_keystore.Models.Products;

namespace backend_keystore.Models.Receipts;

public class CampaignReceipt
{
    public string Id { get; set; } = null!;
    public double Price { get; set; }
    
    public List<Product> Products { get; set; }
    

}