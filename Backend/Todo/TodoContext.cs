using Microsoft.EntityFrameworkCore;

namespace Backend;

public sealed class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options) : base(options) {}
    
    public DbSet<Todo> Todos { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Todo>()
            .HasKey(todo => todo.TodoId);

        modelBuilder.Entity<Todo>()
            .Property(todo => todo.TodoId)
            .ValueGeneratedOnAdd();
    }
}