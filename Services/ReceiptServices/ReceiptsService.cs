using backend_keystore.Data;
using backend_keystore.Models;
using backend_keystore.Models.EAN;
using backend_keystore.Models.Products;
using backend_keystore.Models.Receipts;
using Microsoft.EntityFrameworkCore;

namespace backend_keystore.Services.ReceiptServices;

public class ReceiptsService: IReceiptsService
{
    private readonly DataContext _context;

    public ReceiptsService(DataContext context)
    {
        _context = context;
    }

    public async Task<ServiceResponse<Receipt>> CreateReceipt(List<Product> getShoppingChart)
    {
        List<EanCampaign> campaignEaNs = await _context.EANCampaign.ToListAsync();
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
            NormalPriceReceipt = null,
            TotalPrice =  Math.Round(price, 2)
        };

        
        _context.Receipt.Add(receipt);
        await _context.SaveChangesAsync();
        
        var serviceResponse = new ServiceResponse<Receipt>();
        serviceResponse.Data = receipt;
        return serviceResponse;
    }

    public Task<CampaignReceipt> CreateCampaignReceipt(List<Product> shoppingChart,List<long> campaignEaNs, int campaignPrice)
    {
        Guid uuid = Guid.NewGuid();
        List<Product> itemLists = (from product in shoppingChart
                join ean in campaignEaNs on product.Ean equals ean
                select product)
            .ToList();

        //Se ifall antalet producter som är giltiga för kampanj är ett jämt eller ojämt tal
        if (itemLists.Count % 2 == 0)
        {
            // om de är ett jämt tal. dividerar med 2 -> returnera reultatat gånger kampanjpriset
            //plus resterande varor som ej med i Kampanjen
            int nrOfDiscountProducts = (itemLists.Count / 2);

            double price = nrOfDiscountProducts * campaignPrice;
           
            return Task.FromResult(new CampaignReceipt
            {
                Id = uuid.ToString(),
                Products = itemLists,
                Price = price
            });
        }
        else
        {


            int nrOfDicountProducts = (itemLists.Count / 2);
            double discountPrice = nrOfDicountProducts * campaignPrice;

            //plocka ut sista producten som gav en udda siffra och ej har kampanjpris
            //i och med List börjar från index 0 måste itemLists.Count minskas med 1
            Product nonDicountProduct = itemLists[itemLists.Count - 1];

            // sammansätt rabbaterade priset pluss priset fron producten som blev udda ut
            // och var ej giltig för kampanjpris plus resterande varor som ej med i Kampanjen


            double price = discountPrice + nonDicountProduct.Price;

            return Task.FromResult(new CampaignReceipt()
            {
                Id = uuid.ToString(),
                Products = itemLists,
                Price = Math.Round(price, 2)
            });

        }
    }

    public Task<NormalPriceReceipt> CreateNormalPriceReceipt(List<Product> shoppingChart,List<long> campaignEaNs)
    {
        Guid uuid = Guid.NewGuid();
        // filterar bort alla producter som har EAN tillhörande kampanjpris
        List<Product> itemList = (from product in shoppingChart
                where !campaignEaNs.Contains(product.Ean)
                select product)
            .ToList();

        // Ett alternativt vis att filterar bort producter som ej tillhör kampanj
        //List<Product> itemLists = shoppingCart
        //    .Where(p => !campaignEANs.Any(x => x == p.EAN))
        //    .ToList();


        // returnera summan av alla varor som inte är med i kampanj
        double price = itemList.Sum(prod => prod.Price);

        return Task.FromResult(new NormalPriceReceipt()
        {
            Id = uuid.ToString(),
            Products = itemList,
            Price = Math.Round(price, 2)
        });

    }
}