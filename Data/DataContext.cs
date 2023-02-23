using backend_keystore.Models.EAN;
using backend_keystore.Models.Products;
using backend_keystore.Models.Receipts;
using backendkeystore.Migrations;
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
        modelBuilder.Entity<Product>().HasData(
            new Product { Id = "1", Name = "Coca-cola", EAN = 5000112637922, Price = 19.95 },
            new Product { Id = "2", Name = "Sprite", EAN = 5000112637939, Price = 19.95  },
            new Product { Id = "3", Name = "Pepsi", EAN = 7310865004703, Price = 19.95 },
            new Product { Id = "4", Name = "Seven-upp", EAN = 7340005404261, Price = 19.95  },
            new Product { Id = "5", Name = "Fanta", EAN = 7310532109090, Price = 19.95  },
            new Product { Id = "6", Name = "Glass", EAN = 5000112555922, Price = 19.75 },
            new Product { Id = "7", Name = "Mjöl", EAN = 5000112666622, Price = 25.50 },
            new Product { Id = "8", Name = "Champo", EAN = 5000112337922, Price = 18.59 }
         
        );
        
        modelBuilder.Entity<EANCampaign>().HasData(
            new EANCampaign {Id  = "1",CampaignEAN = 5000112637922 },
            new EANCampaign {Id  = "2",CampaignEAN = 5000112637939 },
            new EANCampaign {Id  = "3",CampaignEAN = 7310865004703},
            new EANCampaign {Id  = "4",CampaignEAN = 7340005404261},
            new EANCampaign {Id  = "5",CampaignEAN = 7310532109090},
            new EANCampaign {Id  = "6",CampaignEAN = 7611612222105}
         
        );
    }
    public DbSet<Product> Product { get; set; }
    public DbSet<EANCampaign> EANCampaign=> Set<EANCampaign>();
    public DbSet<Receipt> Receipt => Set<Receipt>();
}