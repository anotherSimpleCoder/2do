﻿using Backend.Exceptions;
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

        if (_todoService == null)
        {
            throw new Exception("No TodoService found to be tested!");
        }
        
        _todoService.DeleteAllTodos();
        _testTodo = new TodoBuilder()
            .Name("Test Todo")
            .Description("This is a test")
            .Done(false)
            .Build();
    }

    [Test]
    public void AddTodo_ShouldBeOkay()
    {
        var addedTodo = _todoService.AddTodo(_testTodo);
        Assert.That(addedTodo, Is.Not.Null);
    }

    [Test]
    public async Task AddTodoAndGetIt_ShouldBeEqual()
    {
        var addedTodo = await _todoService.AddTodo(_testTodo);
        Assert.That(addedTodo, Is.Not.Null);

        var gottenTodo = await _todoService.GetTodo(addedTodo.TodoId);
        Assert.That(gottenTodo, Is.Not.Null);
        
        Assert.That(addedTodo, Is.EqualTo(gottenTodo));
    }

    [Test]
    public async Task AddTodoAndGetAllTodos_ShouldBeIncluded()
    {
        var addedTodo = await _todoService.AddTodo(_testTodo);
        Assert.That(addedTodo, Is.Not.Null);

        var allTodos = await _todoService.GetAllTodos();
        Assert.That(allTodos.Contains(addedTodo), Is.True);
    }

    [Test]
    public async Task AddTodoAndDeleteIt_ShouldBeOk()
    {
        var addedTodo = await _todoService.AddTodo(_testTodo);
        Assert.That(addedTodo, Is.Not.Null);

        var deletedTodo = await _todoService.DeleteTodo(addedTodo.TodoId);
        Assert.That(deletedTodo, Is.Not.Null);
        
        Assert.That(deletedTodo, Is.EqualTo(addedTodo));
    }

    [Test]
    public async Task AddTodoDeleteItAndGetIt_ShouldThrowNotFound()
    {
        var addedTodo = await _todoService.AddTodo(_testTodo);
        Assert.That(addedTodo, Is.Not.Null);

        var deletedTodo = await _todoService.DeleteTodo(addedTodo.TodoId);
        Assert.That(deletedTodo, Is.Not.Null);
        
        Assert.ThrowsAsync<TodoNotFoundException>(async () => await _todoService.GetTodo(addedTodo.TodoId));
    }
    
    [Test]
    public async Task AddTodoAndDeleteItAndGetAll_ShouldNotBeIncluded()
    {
        var addedTodo = await _todoService.AddTodo(_testTodo);
        Assert.That(addedTodo, Is.Not.Null);

        var deletedTodo = await _todoService.DeleteTodo(addedTodo.TodoId);
        Assert.That(deletedTodo, Is.EqualTo(addedTodo));

        var allTodos = await _todoService.GetAllTodos();
        Assert.That(allTodos.Contains(addedTodo), Is.False);
    }

    [Test]
    public async Task AddTodoAndEditIt_ShouldBeOkay()
    {
        var addedTodo = await _todoService.AddTodo(_testTodo);
        Assert.That(addedTodo, Is.Not.Null);

        var edit = new TodoBuilder()
            .From(addedTodo)
            .Done(true)
            .Build();

        var editedTodo = await _todoService.EditTodo(edit);
        
        Assert.That(editedTodo, Is.Not.Null);
        Assert.That(addedTodo.Done, Is.True);
    }
}