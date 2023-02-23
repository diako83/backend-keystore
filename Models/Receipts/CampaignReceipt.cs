using backend_keystore.Models.Products;

namespace backend_keystore.Models.Receipts;

public class CampaignReceipt
{
    public string Id { get; set; } = string.Empty;
    public List<Product> shoppingCart { get; set; } = new List<Product>();
    public double Price { get; set; }
    public Receipt Receipt { get; set; }
    public string ReceiptId { get; set; }
}