using backend_keystore.Models.EAN;
using backend_keystore.Models.Products;
using backend_keystore.Models.Receipts;

using Microsoft.EntityFrameworkCore;

namespace backend_keystore.Data;

public class DataContext:DbContext
{
    protected DataContext()
    {
    }

    public DataContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        /*modelBuilder.Entity<CampaignReceipt>()
            .HasMany(p => p.ProductIds)
            .WithOne(c => c.CampaignReceipt)
            .HasForeignKey(k => k.CampaignReceiptId)
            .IsRequired(false);

        modelBuilder.Entity<NormalPriceReceipt>()
            .HasMany(p => p.ProductIds)
            .WithOne(n => n.NormalPriceReceipt)
            .HasForeignKey(k => k.NormalPriceReceiptId)
            .IsRequired(false);;*/

        modelBuilder.Entity<Product>().HasData(
            new Product { Id = "1", Name = "Coca-cola", Ean = 5000112637922, Price = 19.95 },
            new Product { Id = "2", Name = "Sprite", Ean = 5000112637939, Price = 19.95  },
            new Product { Id = "3", Name = "Pepsi", Ean = 7310865004703, Price = 19.95 },
            new Product { Id = "4", Name = "Seven-upp", Ean = 7340005404261, Price = 19.95  },
            new Product { Id = "5", Name = "Fanta", Ean = 7310532109090, Price = 19.95  },
            new Product { Id = "6", Name = "Glass", Ean = 5000112555922, Price = 19.75 },
            new Product { Id = "7", Name = "Mjöl", Ean = 5000112666622, Price = 25.50 },
            new Product { Id = "8", Name = "Champo", Ean = 5000112337922, Price = 18.59 }
         
        );
        
        modelBuilder.Entity<EanCampaign>().HasData(
            new EanCampaign {Id  = "1",CampaignEan = 5000112637922 },
            new EanCampaign {Id  = "2",CampaignEan = 5000112637939 },
            new EanCampaign {Id  = "3",CampaignEan = 7310865004703},
            new EanCampaign {Id  = "4",CampaignEan = 7340005404261},
            new EanCampaign {Id  = "5",CampaignEan = 7310532109090},
            new EanCampaign {Id  = "6",CampaignEan = 7611612222105}
         
        );
    }

    public DbSet<Product> Product => Set<Product>();
    public DbSet<EanCampaign> EANCampaign=> Set<EanCampaign>();
    public DbSet<Receipt> Receipt => Set<Receipt>();
    public DbSet<CampaignReceipt> CampaignReceipts => Set<CampaignReceipt>();
    public DbSet<NormalPriceReceipt> NormalPriceReceipt => Set<NormalPriceReceipt>();
}