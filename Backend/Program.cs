using System.Data.Common;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Backend;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddCors(options =>
        {
            options.AddPolicy(
                name: "Dev Origins",
                policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
            );
        });

        var dbConnectionString = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test.db");
        builder.Services.AddDbContext<TodoContext>(options => options.UseSqlite($"Data Source={dbConnectionString}"), ServiceLifetime.Scoped);
        builder.Services.AddSingleton<TodoService>();
        builder.Services.AddControllers();
        
        var app = builder.Build();
        app.MapControllers();
        app.UseCors("Dev Origins");
        
        app.Run();
    }
}