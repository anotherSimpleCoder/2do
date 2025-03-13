using System;
using System.Data.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace Backend.Config;

public class DatabaseConfig : IHostingStartup
{
    public void Configure(IWebHostBuilder builder)
    {
        builder.Configure(app =>
        {
            ConfigureDatabase(app.ApplicationServices);
        });
    }

    private void ConfigureDatabase(IServiceProvider serviceProvider)
    {
        var connection = serviceProvider.GetRequiredService<DbConnection>();
        var compiler = serviceProvider.GetRequiredService<Compiler>();
        var sql = new QueryFactory(connection, compiler);
        connection.Open();
        
        CreateTodoTable(sql);
    }
    
    private void CreateTodoTable(QueryFactory sql)
    {
        sql.Statement(@"
            create table if not exists Todos (
                TodoId integer primary key autoincrement,
                Name varchar(255),
                Description text,
                Done boolean
            );
        ");
    }
}