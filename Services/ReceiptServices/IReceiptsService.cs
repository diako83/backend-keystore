using backend_keystore.Dto;
using backend_keystore.Dto.RecieptsDto;
using backend_keystore.Models;
using backend_keystore.Models.Products;
using backend_keystore.Models.Receipts;

namespace backend_keystore.Services.ReceiptServices;

public interface IReceiptsService
{

    Task<ServiceResponse<ReceiptDto>> CreateReceipt(List<ProductDto> getShoppingChart);
    Task<CampaignReceipt>CreateCampaignReceipt(List<ProductDto> shoppingChart,List<long> campaignEANs,int campaignPrice);
    Task<NormalPriceReceipt> CreateNormalPriceReceipt(List<ProductDto> getShoppingChart,List<long> campaignEANs);
    
}