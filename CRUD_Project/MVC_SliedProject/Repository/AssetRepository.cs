using MVC_SliedProject.Models;

public interface IAssetRepository
{
    Task<IEnumerable<Asset>> GetAssetsAsync(string category = null);
}
