using System.Security.Claims;
using backend_keystore.Data;
using backend_keystore.Dto;
using backend_keystore.Dto.RecieptsDto;
using backend_keystore.Models;
using backend_keystore.Models.EAN;
using backend_keystore.Models.Products;
using backend_keystore.Models.Receipts;
using backend_keystore.Models.User;
using Microsoft.EntityFrameworkCore;

namespace backend_keystore.Services.ReceiptServices;

public class ReceiptsService: IReceiptsService
{
    private readonly DataContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ReceiptsService(DataContext context,IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    private string GetUserId() => _httpContextAccessor.HttpContext!.User
        .FindFirstValue(ClaimTypes.NameIdentifier)!;
    private User GetUser()
    {
        var userIdClaim = _httpContextAccessor.HttpContext!.User.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim == null)
        {
            throw new Exception("User not authenticated or NameIdentifier claim is missing.");
        }
        
        var userId = userIdClaim.Value;

        var user = _context.Users.FirstOrDefault(u => u.Id == userId);

        return user;
    }
    
    public async Task<ServiceResponse<ReceiptDto>> CreateReceipt(List<ProductDto> getShoppingChart)
    {
        List<EanCampaign> campaignEaNs = await _context.EANCampaigns.ToListAsync();
        if (campaignEaNs == null) throw new ArgumentNullException(nameof(campaignEaNs));
        List<long> eans = campaignEaNs.Select(c => c.CampaignEan).ToList();
        CampaignReceipt campaignReceipt = await CreateCampaignReceipt( getShoppingChart ,eans,30);
        NormalPriceReceipt normalPriceReceipt = await CreateNormalPriceReceipt(getShoppingChart, eans);
        
        double price = campaignReceipt.Price + normalPriceReceipt.Price;
        Guid uuid = Guid.NewGuid();
        
        Receipt receipt = new Receipt()
        {
            Id = uuid.ToString() ,
            Date = DateTime.UtcNow,
            CampaignReceipt = campaignReceipt,
            NormalPriceReceipt = normalPriceReceipt,
            TotalPrice =  Math.Round(price, 2),
            User = GetUser()
        };
        
        _context.Receipts.Add(receipt);
        await _context.SaveChangesAsync();


        var receiptDto = CreateReceiptDto(campaignReceipt, normalPriceReceipt, receipt);

        var serviceResponse = new ServiceResponse<ReceiptDto>();
        serviceResponse.Data = receiptDto;
        serviceResponse.Message = "Thank you for shopping att KeyStore";
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<ReceiptDto>>> GetAllReceipts()
    {
        
        
        
        var serviceResponse = new ServiceResponse<List<ReceiptDto>>();
        List<Receipt> receipts = await _context.Receipts
            .Include(c=>c.CampaignReceipt)
            .Include(c=>c.NormalPriceReceipt)
            .Where(c => c.User.Id == GetUserId()).ToListAsync();

        List<ReceiptDto> receiptsDtos = 
          receipts.Select(r =>  CreateReceiptDto(r.CampaignReceipt, r.NormalPriceReceipt, r)).ToList();

        serviceResponse.Data = receiptsDtos;
        serviceResponse.Message = $"$All receipt connected to id {GetUserId()}";

        return serviceResponse;
    }

    private ReceiptDto CreateReceiptDto(CampaignReceipt campaignReceipt, NormalPriceReceipt normalPriceReceipt,
        Receipt receipt)
    {
        List<Product> campaignReceiptProducts = _context.Product
            .Where(p => campaignReceipt.ProductIds.Contains(p.Id)).ToList();
        List<Product> normalPriceReceiptProducts = _context.Product
            .Where(p => normalPriceReceipt.ProductIds.Contains(p.Id)).ToList();

        CampaignReceiptDto campaignReceiptDto = new CampaignReceiptDto
            { Id = campaignReceipt.Id, Price = campaignReceipt.Price, Products = campaignReceiptProducts };
        NormalPriceReceiptDto normalPriceReceiptDto = new NormalPriceReceiptDto
            { Id = normalPriceReceipt.Id, Price = normalPriceReceipt.Price, Products = normalPriceReceiptProducts };

        ReceiptDto receiptDto = new ReceiptDto
        {
            Id = receipt.Id, Date = receipt.Date, CampaignReceipt = campaignReceiptDto,
            NormalPriceReceipt = normalPriceReceiptDto, TotalPrice = receipt.TotalPrice
        };
        return receiptDto;
    }

    public async Task<CampaignReceipt> CreateCampaignReceipt(List<ProductDto> shoppingChart,List<long> campaignEaNs, int campaignPrice)
    {
        Guid uuid = Guid.NewGuid();
        List<ProductDto> itemDtoLists = (from product in shoppingChart
                join ean in campaignEaNs on product.Ean equals ean
                select product)
            .ToList();

        List<Product> itemList = itemDtoLists.Select(dto => new Product
        {
            Id = dto.Id, Name = dto.Name, Ean = dto.Ean, Price = dto.Price
        }).ToList();
        //Se ifall antalet producter som är giltiga för kampanj är ett jämt eller ojämt tal
        if (itemList.Count % 2 == 0)
        {
            // om de är ett jämt tal. dividerar med 2 -> returnera reultatat gånger kampanjpriset
            //plus resterande varor som ej med i Kampanjen
            int nrOfDiscountProducts = (itemList.Count / 2);

            double price = nrOfDiscountProducts * campaignPrice;

            List<string> productIds = itemList.Select(x => x.Id).ToList();
           CampaignReceipt campaignReceipt= new CampaignReceipt
            {
                Id = uuid.ToString(),
                ProductIds = productIds,
                Price = price
            };
            
            _context.CampaignReceipts.Add(campaignReceipt);
            await _context.SaveChangesAsync();
            
            
            return  campaignReceipt;
        }
        else
        {
            
            int nrOfDicountProducts = (itemList.Count / 2);
            double discountPrice = nrOfDicountProducts * campaignPrice;

            //plocka ut sista producten som gav en udda siffra och ej har kampanjpris
            //i och med List börjar från index 0 måste itemLists.Count minskas med 1
            Product nonDicountProduct = itemList[itemList.Count - 1];

            // sammansätt rabbaterade priset pluss priset fron producten som blev udda ut
            // och var ej giltig för kampanjpris plus resterande varor som ej med i Kampanjen


            double price = discountPrice + nonDicountProduct.Price;
                
            List<string> productIds = itemList.Select(x => x.Id).ToList();
            CampaignReceipt campaignReceipt= new CampaignReceipt
            {
                Id = uuid.ToString(),
                ProductIds = productIds,
                Price = Math.Round(price, 2)
            };
            
            _context.CampaignReceipts.Add(campaignReceipt);
            await _context.SaveChangesAsync();
            
            
            return  campaignReceipt;
        }
    }

    public Task<NormalPriceReceipt> CreateNormalPriceReceipt(List<ProductDto> shoppingChart,List<long> campaignEaNs)
    {
        Guid uuid = Guid.NewGuid();
        // filterar bort alla producter som har EAN tillhörande kampanjpris
        List<ProductDto> itemDtoList = (from product in shoppingChart
                where !campaignEaNs.Contains(product.Ean)
                select product)
            .ToList();
        List<Product> itemList = itemDtoList.Select(dto => new Product
        {
            Id = dto.Id, Name = dto.Name, Ean = dto.Ean, Price = dto.Price
        }).ToList();
        // Ett alternativt vis att filterar bort producter som ej tillhör kampanj
        //List<Product> itemLists = shoppingCart
        //    .Where(p => !campaignEANs.Any(x => x == p.EAN))
        //    .ToList();


        // returnera summan av alla varor som inte är med i kampanj
        double price = itemList.Sum(prod => prod.Price);
        List<string> productIds = itemList.Select(x => x.Id).ToList();
        return Task.FromResult(new NormalPriceReceipt()
        {
            Id = uuid.ToString(),
            ProductIds = productIds,
            Price = Math.Round(price, 2)
        });

    }
}