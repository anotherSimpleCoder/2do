using Backend.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Backend;

public class TodoService
{
    private TodoContext _sql;

    public TodoService(IServiceProvider serviceProvider)
    {
        var scope = serviceProvider.CreateScope();
        _sql = scope.ServiceProvider.GetRequiredService<TodoContext>();
        if (_sql == null)
        {
            throw new Exception("TodoContext not found!");
        }
        
        _sql.Database.EnsureCreated();
    }
    
    public async Task<Todo> AddTodo(Todo todoToAdd)
    {
        await _sql.Todos
            .AddAsync(todoToAdd);
        
        await _sql.SaveChangesAsync();

        return todoToAdd;
    }

    public async Task<List<Todo>> GetAllTodos()
    {
        return await _sql.Todos
            .ToListAsync();
    }
    
    public async Task<Todo> GetTodo(int todoId)
    {
        var todo = await _sql.Todos
            .FirstOrDefaultAsync(todo => todo.TodoId == todoId);

        if (todo == null)
        {
            throw new TodoNotFoundException();
        }
        
        return todo;
    }

    public async Task<Todo> DeleteTodo(int todoId)
    {
        var deleted = await GetTodo(todoId);

        await _sql.Todos
            .Where(todo => todo.TodoId == todoId)
            .ExecuteDeleteAsync();

        return deleted;
    }

    public async Task<Todo> EditTodo(Todo todoToEdit)
    {
        var foundTodo = await _sql.Todos
            .FindAsync(todoToEdit.TodoId);
        
        foundTodo.Name = todoToEdit.Name;
        foundTodo.Description = todoToEdit.Description;
        foundTodo.Done = todoToEdit.Done;
        await _sql.SaveChangesAsync();

        return await GetTodo(todoToEdit.TodoId);
    }
    
    public async Task DeleteAllTodos()
    {
       await _sql.Todos.ExecuteDeleteAsync();
    }
}