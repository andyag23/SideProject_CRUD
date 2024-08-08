using System.Data;
using Microsoft.Data.SqlClient;
using WebAPI.Repository;
using WebAPI.Service;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                // 配置 SQL Server 連接
                services.AddScoped<IDbConnection>(provider =>
                {
                    var connectionString = context.Configuration.GetConnectionString("DefaultConnection");
                    return new SqlConnection(connectionString);
                });

                // 配置其他服務
                services.AddControllers();
                services.AddScoped<IAssetRepository, AssetService>();
            });
}
