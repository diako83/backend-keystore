using backend_keystore.Models;
using backend_keystore.Models.Products;
using backend_keystore.Models.Receipts;

namespace backend_keystore.Services.ReceiptServices;

public class ReceiptsService: IReceiptsService
{
    public Task<ServiceResponse<Receipt>> CreateReceipt(List<Product> getShoppingChart)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<CampaignReceipt>> CreateCampaignReceipt(List<Product> getShoppingChart, int campaignPrice)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<NormalPriceReceipt>> CreateNormalPriceReceipt(List<Product> getShoppingChart)
    {
        throw new NotImplementedException();
    }
}