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
                // �t�m SQL Server �s��
                services.AddScoped<IDbConnection>(provider =>
                {
                    var connectionString = context.Configuration.GetConnectionString("DefaultConnection");
                    return new SqlConnection(connectionString);
                });

                // �t�m��L�A��
                services.AddControllers();
                services.AddScoped<IAssetRepository, AssetService>();
            });
}
