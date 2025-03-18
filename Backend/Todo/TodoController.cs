using Microsoft.AspNetCore.Mvc;

namespace Backend;

[ApiController]
[Route("api/todo")]
public class TodoController : ControllerBase
{
    private readonly TodoService _todoService;

    public TodoController(TodoService todoService)
    {
        _todoService = todoService;
    }

    [HttpGet]
    public async Task<Todo?> GetTodo(int todoId)
    {
        return _todoService.GetTodo(todoId);
    }

    [HttpGet]
    [Route("all")]
    public async Task<List<Todo>> GetAllTodos()
    {
        return _todoService.GetAllTodos();
    }
    
    [HttpPost]
    public async Task<Todo?> AddTodo(Todo todoToAdd)
    {
        return _todoService.AddTodo(todoToAdd);
    }

    [HttpDelete]
    public async Task<Todo?> DeleteTodo(int todoId)
    {
        return _todoService.DeleteTodo(todoId);
    }
}