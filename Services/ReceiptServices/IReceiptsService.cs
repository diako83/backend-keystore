using backend_keystore.Models;
using backend_keystore.Models.Products;
using backend_keystore.Models.Receipts;

namespace backend_keystore.Services.ReceiptServices;

public interface IReceiptsService
{

    Task<ServiceResponse<Receipt>> CreateReceipt(List<Product> getShoppingChart);
    Task<ServiceResponse<CampaignReceipt>>CreateCampaignReceipt(List<Product> getShoppingChart,int campaignPrice);
    Task<ServiceResponse<NormalPriceReceipt>> CreateNormalPriceReceipt(List<Product> getShoppingChart);
    
}