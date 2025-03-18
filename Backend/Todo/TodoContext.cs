using Microsoft.EntityFrameworkCore;

namespace Backend;

public class TodoContext : DbContext
{
    public DbSet<Todo> Todos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Todo>()
            .HasKey(todo => todo.TodoId);

        modelBuilder.Entity<Todo>()
            .Property(todo => todo.TodoId)
            .ValueGeneratedOnAdd();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var dbConnectionString = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test.db");
        optionsBuilder.UseSqlite($"Data Source={dbConnectionString}");
    }
}