using Microsoft.EntityFrameworkCore;
using AssetManagement.WebApi.Models;

namespace AssetManagement.WebApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Asset> Assets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Asset>().HasData(
                new Asset { Id = "AVAIN-01", Name = "P‰‰oven kulkul‰tk‰", DeviceType = "Avain", Status = "Vapaa" },
                new Asset { Id = "IPAD-04", Name = "Aulan esittelyp‰‰te", DeviceType = "Tabletti", Status = "Lainassa", BorrowedBy = "Benjamin Masena" },
                new Asset { Id = "REITITIN-02", Name = "Neuvotteluhuoneen reititin", DeviceType = "Verkkolaite", Status = "Huollossa" }
            );
        }
    }
}
