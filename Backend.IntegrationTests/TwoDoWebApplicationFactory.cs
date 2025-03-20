using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
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
            services.AddDbContext<TodoContext>(options => options.UseSqlite($"Data Source={dbConnectionString}"), ServiceLifetime.Scoped);
            
            services.RemoveAll<TodoService>();
            services.AddSingleton<TodoService>();
        });
        
        base.ConfigureWebHost(builder);
    }
}