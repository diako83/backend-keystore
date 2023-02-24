namespace backend_keystore.Dto;

public class ProductDto
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = string.Empty;
    public long Ean { get; set; } 
    public double Price { get; set; }

    public ProductDto(string id, string name, long ean, double price)
    {
        Id = id;
        Name = name;
        Ean = ean;
        Price = price;
    }
}