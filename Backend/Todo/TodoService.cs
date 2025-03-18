using Backend.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Backend;

public class TodoService
{
    private TodoContext _sql;

    public TodoService(IServiceProvider serviceProvider)
    {
        _sql = new TodoContext();
        _sql.Database.EnsureCreated();
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

    public Todo? EditTodo(Todo todoToEdit)
    {
        var foundTodo = _sql.Todos
            .Find(todoToEdit.TodoId);
        
        foundTodo.Name = todoToEdit.Name;
        foundTodo.Description = todoToEdit.Description;
        foundTodo.Done = todoToEdit.Done;
        _sql.SaveChanges();

        return GetTodo(todoToEdit.TodoId);
    }
    
    public void DeleteAllTodos()
    {
        _sql.Todos.ExecuteDelete();
    }
}