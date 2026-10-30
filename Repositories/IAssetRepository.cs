using AssetManagement.WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssetManagement.WebApi.Repositories
{
    public interface IAssetRepository
    {
        Task<IEnumerable<Asset>> GetAllAsync();
        Task<Asset?> GetByIdAsync(string id);
        Task<bool> UpdateAsync(Asset asset);
    }
}
