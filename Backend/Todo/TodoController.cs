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
        return await _todoService.GetTodo(todoId);
    }

    [HttpGet]
    [Route("all")]
    public async Task<List<Todo>> GetAllTodos()
    {
        return await _todoService.GetAllTodos();
    }
    
    [HttpPost]
    public async Task<Todo?> AddTodo(Todo todoToAdd)
    {
        return await _todoService.AddTodo(todoToAdd);
    }

    [HttpDelete]
    public async Task<Todo?> DeleteTodo(int todoId)
    {
        return await _todoService.DeleteTodo(todoId);
    }

    
    [HttpDelete]
    [Route("all")]
    public async Task DeleteAllTodos()
    {
        await _todoService.DeleteAllTodos();
    }
}