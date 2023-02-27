
namespace backend_keystore.Models.Receipts;
using backend_keystore.Models.User;


public class Receipt
{
    public string Id { get; set; } = null!;
    public DateTime Date { get; set; }
    public CampaignReceipt? CampaignReceipt { get; set; }
    public NormalPriceReceipt? NormalPriceReceipt { get; set; }
    public double TotalPrice { get; set; }
    
    public  User? User { get; set; }
}