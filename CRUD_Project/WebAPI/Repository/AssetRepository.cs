using WebAPI.Model;

namespace WebAPI.Repository
{
    public interface IAssetRepository
    {
        Task<IEnumerable<Asset>> GetAllAsync();
        Task<Asset> GetByIdAsync(int id);
        Task CreateAsync(Asset asset);
        Task UpdateAsync(Asset asset);
        Task DeleteAsync(int id);
    }
}
