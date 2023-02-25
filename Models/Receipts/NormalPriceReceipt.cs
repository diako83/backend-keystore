using backend_keystore.Models.Products;

namespace backend_keystore.Models.Receipts;

public class NormalPriceReceipt
{
    public string Id { get; set; } = null!;
    public double Price { get; set; }

    public List<string> ProductIds { get; set; } = null!;
}