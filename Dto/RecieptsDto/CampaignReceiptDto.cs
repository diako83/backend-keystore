using backend_keystore.Models.Products;

namespace backend_keystore.Dto.RecieptsDto;

public class CampaignReceiptDto
{
    public string Id { get; set; } = null!;
    public double Price { get; set; }

    public List<Product> Products { get; set; } = null!;
}