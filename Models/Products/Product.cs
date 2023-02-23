namespace backend_keystore.Models.Products;

public class Product
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = "test";
    public long EAN { get; set; } = 00;
    public double Price { get; set; } = 00;
}