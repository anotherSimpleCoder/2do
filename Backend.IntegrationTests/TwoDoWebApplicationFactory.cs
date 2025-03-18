using System.Data.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Backend.IntegrationTests;

internal class TwoDoWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.AddControllers();
            
            var dbConnectionString = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test.db");
            var dbConnection = new SqliteConnection($"Data Source={dbConnectionString}");
            dbConnection.Open();

            services.RemoveAll<DbConnection>();
            services.AddSingleton<DbConnection>(dbConnection);

            services.RemoveAll<TodoService>();
            services.AddSingleton<TodoService>();
        });
        
        base.ConfigureWebHost(builder);
    }
}