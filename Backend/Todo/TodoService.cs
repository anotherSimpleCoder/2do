using Backend.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Backend;

public class TodoService
{
    private TodoContext _sql;

    public TodoService(IServiceProvider serviceProvider)
    {
        _sql = new TodoContext();
    }
    
    public Todo? AddTodo(Todo todoToAdd)
    {
        _sql.Todos
            .Add(todoToAdd);
        
        _sql.SaveChanges();

        return todoToAdd;
    }

    public List<Todo> GetAllTodos()
    {
        return _sql.Todos
            .ToList();
    }
    
    public Todo? GetTodo(int todoId)
    {
        var todo = _sql.Todos
            .FirstOrDefault(todo => todo.TodoId == todoId);

        if (todo == null)
        {
            throw new TodoNotFoundException();
        }
        
        return todo;
    }

    public Todo? DeleteTodo(int todoId)
    {
        var deleted = GetTodo(todoId);

        _sql.Todos
            .Where(todo => todo.TodoId == todoId)
            .ExecuteDelete();

        return deleted;
    }

    public void DeleteAllTodos()
    {
        _sql.Todos.ExecuteDelete();
    }
}