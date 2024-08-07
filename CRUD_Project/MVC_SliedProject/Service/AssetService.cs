using Dapper;
using Microsoft.Data.SqlClient;
using MVC_SliedProject.Models;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

public class AssetRepository : IAssetRepository
{
    private readonly string _connectionString;

    public AssetRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<IEnumerable<Asset>> GetAssetsAsync(string category = null)
    {
        using (IDbConnection dbConnection = new SqlConnection(_connectionString))
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Category", category, DbType.String, ParameterDirection.Input);

            // 調用存儲過程
            return await dbConnection.QueryAsync<Asset>(
                "GetAssets",  // 存儲過程名稱
                parameters,
                commandType: CommandType.StoredProcedure);
        }
    }
}
