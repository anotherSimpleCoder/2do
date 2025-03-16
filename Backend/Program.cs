using System.Data.Common;
using Backend.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace Backend;

public class Program
{
    public static void Main(string[] args)
    {
        var dbConnectionString = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test.db");
        var dbConnection = new SqliteConnection($"Data Source={dbConnectionString}");
        dbConnection.Open();
        
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddSingleton<DbConnection>(dbConnection);

        var compiler = new SqliteCompiler();
        builder.Services.AddSingleton<Compiler>(compiler);

        builder.Services.AddSingleton(new QueryFactory(dbConnection, compiler));
        
        builder.Services.AddSingleton<TodoService>();
        builder.Services.AddControllers();

        
        
        var app = builder.Build();
        DatabaseConfig.ConfigureDatabase(app.Services);
        app.MapControllers();
        
        
        app.Run();
    }
}