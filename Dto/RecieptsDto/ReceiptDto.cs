namespace backend_keystore.Dto.RecieptsDto;

public class ReceiptDto
{
    public string Id { get; set; } = null!;
    public DateTime Date { get; set; }
    public CampaignReceiptDto? CampaignReceipt { get; set; }
    public NormalPriceReceiptDto? NormalPriceReceipt { get; set; }
    public double TotalPrice { get; set; }
}