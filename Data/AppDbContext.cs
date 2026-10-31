using Microsoft.EntityFrameworkCore;
using AssetManagement.WebApi.Models;
using System;

namespace AssetManagement.WebApi.Data
{
    // DbContext kääntää C#-haut SQL-kyselyiksi taustalla
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Tämä luo tietokantaan "Assets"-nimisen taulun Asset-mallin mukaisesti
        public DbSet<Asset> Assets { get; set; }

        // Tällä metodilla syötetään valmista testidataa tietokantaan (Data Seeding)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var defaultDate = new DateTime(2026, 10, 31, 0, 0, 0, DateTimeKind.Utc);
            // Kun tietokanta luodaan ensimmäistä kertaa, sinne lisätään nämä kolme riviä automaattisesti
            modelBuilder.Entity<Asset>().HasData(
                new Asset { Id = "AVAIN-01", Name = "Pääoven kulkulätkä", DeviceType = "Avain", Status = "Vapaa" },
                new Asset { Id = "IPAD-04", Name = "Aulan esittelypääte", DeviceType = "Tabletti", Status = "Lainassa", BorrowedBy = "Benjamin Masena" },
                new Asset { Id = "REITITIN-02", Name = "Neuvotteluhuoneen reititin", DeviceType = "Verkkolaite", Status = "Huollossa" }
            );
        }
    }
}
