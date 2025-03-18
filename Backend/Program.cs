using System.Data.Common;
using Microsoft.Data.Sqlite;

namespace Backend;

public class Program
{
    public static void Main(string[] args)
    {
        var dbConnectionString = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test.db");
        var dbConnection = new SqliteConnection($"Data Source={dbConnectionString}");
        dbConnection.Open();
        
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddCors(options =>
        {
            options.AddPolicy(
                name: "Dev Origins",
                policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
            );
        });
        
        builder.Services.AddSingleton<DbConnection>(dbConnection);
        
        builder.Services.AddSingleton<TodoService>();
        builder.Services.AddControllers();
        
        var app = builder.Build();
        app.MapControllers();
        app.UseCors("Dev Origins");
        
        app.Run();
    }
}