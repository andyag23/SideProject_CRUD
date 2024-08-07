using MVC_SliedProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IAssetRepository
{
    Task<IEnumerable<Asset>> GetAssetsAsync(string category = null);
}
