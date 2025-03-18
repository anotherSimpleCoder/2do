using System.Data.Common;
using Microsoft.Data.Sqlite;

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
        
        builder.Services.AddSingleton<TodoService>();
        builder.Services.AddControllers();
        
        var app = builder.Build();
        app.MapControllers();
        app.UseCors("Dev Origins");
        
        app.Run();
    }
}