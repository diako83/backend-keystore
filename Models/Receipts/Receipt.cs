namespace backend_keystore.Models.Receipts;

public class Receipt
{
    public string Id { get; set; } = string.Empty;
    public DateTime date { get; set; } = new DateTime();
    public CampaignReceipt? CampaignReceipt { get; set; }
    public NormalPriceReceipt? NormalPriceReceipt { get; set; }
    public double TotalPrice { get; set; }
}