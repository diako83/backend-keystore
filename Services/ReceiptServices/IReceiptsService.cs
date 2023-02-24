using backend_keystore.Models;
using backend_keystore.Models.Products;
using backend_keystore.Models.Receipts;

namespace backend_keystore.Services.ReceiptServices;

public interface IReceiptsService
{

    Task<ServiceResponse<Receipt>> CreateReceipt(List<Product> getShoppingChart);
    Task<CampaignReceipt>CreateCampaignReceipt(List<Product> shoppingChart,List<long> campaignEANs,int campaignPrice);
    Task<NormalPriceReceipt> CreateNormalPriceReceipt(List<Product> getShoppingChart,List<long> campaignEANs);
    
}