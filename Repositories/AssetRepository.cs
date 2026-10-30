using AssetManagement.WebApi.Data;
using AssetManagement.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssetManagement.WebApi.Repositories
{
    // Tämä luokka toteuttaa IAssetRepository-rajapinnan (Repository Pattern)
    public class AssetRepository : IAssetRepository
    {
        private readonly AppDbContext _context;

        // Tuodaan tietokantayhteys sisään konstruktorissa (Dependency Injection)
        public AssetRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Asset>> GetAllAsync()
        {
            return await _context.Assets.ToListAsync();
        }

        public async Task<Asset?> GetByIdAsync(string id)
        {
            return await _context.Assets.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(Asset asset)
        {
            _context.Entry(asset).State = EntityState.Modified; // Kerrotaan EF:lle, että data on muuttunut
            return await _context.SaveChangesAsync() > 0; // Tallentaa SQL Serveriin
        }
    }
}
