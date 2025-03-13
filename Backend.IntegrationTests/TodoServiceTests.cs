using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Backend.IntegrationTests;

public class Tests
{
    private TodoService _todoService;
    private Todo _testTodo;
    
    [SetUp]
    public void Setup()
    {
        var app = new TwoDoWebApplicationFactory();
        _todoService = app.Services.GetService<TodoService>();
        
        _testTodo = new TodoBuilder()
            .Name("Test Todo")
            .Description("This is a test")
            .Build();
    }

    [Test]
    public void AddService_ShouldBeOkay()
    {
        var addedTodo = _todoService.AddTodo(_testTodo);
        Assert.That(addedTodo, Is.Not.Null);
    }

    [Test]
    public void AddServiceAndGetIt_ShouldBeEqual()
    {
        var addedTodo = _todoService.AddTodo(_testTodo);
        Assert.That(addedTodo, Is.Not.Null);

        var gottenTodo = _todoService.GetTodo(addedTodo.TodoId);
        Assert.That(gottenTodo, Is.Not.Null);
        
        Assert.That(addedTodo, Is.EqualTo(gottenTodo));
    }

    [Test]
    public void AddServiceAndDeleteIt_ShouldBeOk()
    {
        var addedTodo = _todoService.AddTodo(_testTodo);
        Assert.That(addedTodo, Is.Not.Null);

        var deletedTodo = _todoService.DeleteTodo(addedTodo.TodoId);
        Assert.That(deletedTodo, Is.Not.Null);
        
        Assert.That(deletedTodo, Is.EqualTo(addedTodo));
    }
}