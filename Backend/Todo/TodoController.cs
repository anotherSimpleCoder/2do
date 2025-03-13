using Microsoft.AspNetCore.Mvc;

namespace Backend;

public class TodoController : Controller
{
    private readonly TodoService _todoService;

    public TodoController(TodoService todoService)
    {
        _todoService = todoService;
    }

    [HttpGet]
    public Todo? GetTodo()
    {
        return null;
    }
    
    [HttpPost]
    public Todo? AddTodo()
    {
        return null;
    }

    [HttpDelete]
    public Todo? DeleteTodo()
    {
        return null;
    }
}