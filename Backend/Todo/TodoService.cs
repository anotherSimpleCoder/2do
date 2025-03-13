using System;
using Microsoft.Extensions.DependencyInjection;
using SqlKata.Execution;

namespace Backend;

public class TodoService
{
    private QueryFactory _sql;

    public TodoService(IServiceProvider serviceProvider)
    {
        _sql = serviceProvider.GetService<QueryFactory>();
    }
    
    public Todo? AddTodo(Todo todoToAdd)
    {
        var inserted = _sql.Query("Todos").InsertGetId<int>(new {
            todoToAdd.Name,
            todoToAdd.Description,
            todoToAdd.Done
        });
        
        return GetTodo(inserted);
    }

    public Todo? GetTodo(int todoId)
    {
        return _sql.Query("Todos")
            .Where("TodoId", todoId)
            .First<Todo>();
    }

    public Todo? DeleteTodo(int todoId)
    {
        var deleted = GetTodo(todoId);

        _sql.Query("Todos")
            .Where("TodoId", todoId)
            .AsDelete();
        
        return deleted;
    }
}