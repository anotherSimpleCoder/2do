using System;
using System.Data;
using System.Data.Common;
using System.IO;
using Backend.Config;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace Backend.IntegrationTests;

internal class TwoDoWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var dbConnectionString = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test.db");
            var dbConnection = new SqliteConnection($"Data Source={dbConnectionString}");
            dbConnection.Open();

            services.RemoveAll<IDbConnection>();
            services.AddSingleton<DbConnection>(dbConnection);
            
            var compiler = new SqliteCompiler();
            services.RemoveAll<Compiler>();
            services.AddSingleton<Compiler>(compiler);
            
            services.RemoveAll<QueryFactory>();
            services.AddSingleton(new QueryFactory(dbConnection, compiler));
            
            services.RemoveAll<TodoService>();
            services.AddSingleton<TodoService>();
        });


        var dbConfig = new DatabaseConfig();
        dbConfig.Configure(builder);        
        base.ConfigureWebHost(builder);
    }
}