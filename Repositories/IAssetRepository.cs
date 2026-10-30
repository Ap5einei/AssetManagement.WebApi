using AssetManagement.WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssetManagement.WebApi.Repositories
{
    // Rajapinta määrittää MITÄ toimintoja on olemassa, mutta ei sitä MITEN ne tehdään
    public interface IAssetRepository
    {
        Task<IEnumerable<Asset>> GetAllAsync(); // Hae kaikki laitteet listana
        Task<Asset?> GetByIdAsync(string id); // Hae yksi laite ID:n perusteella
        Task<bool> UpdateAsync(Asset asset); // Päivitä laitteen tiedot
    }
}
