using Dapper;
using System.Data;
using System.Data.Common;
using WebAPI.Model;
using WebAPI.Repository;

namespace WebAPI.Service
{
    public class AssetService : IAssetRepository
    {
        private readonly IDbConnection _dbConnection;

        public AssetService(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Asset>> GetAllAsync()
        {
            return await _dbConnection.QueryAsync<Asset>("usp_AssetsGet", commandType: CommandType.StoredProcedure);
        }

        public async Task<Asset> GetByIdAsync(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            return await _dbConnection.QuerySingleOrDefaultAsync<Asset>("usp_AssetGetById", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task CreateAsync(Asset asset)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Name", asset.Name);
            parameters.Add("@Category", asset.Category);
            await _dbConnection.ExecuteAsync("usp_AssetCreate", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateAsync(Asset asset)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", asset.Id);
            parameters.Add("@Name", asset.Name);
            parameters.Add("@Category", asset.Category);
            await _dbConnection.ExecuteAsync("usp_AssetUpdate", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteAsync(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            await _dbConnection.ExecuteAsync("usp_AssetDelete", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
