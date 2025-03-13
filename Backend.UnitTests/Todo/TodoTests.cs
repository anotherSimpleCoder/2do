using NUnit.Framework;

namespace Backend.UnitTests;

using Backend;

public class Tests
{
    [Test]
    public void CreateTodo_ShouldNotBeNull()
    {
        var newTodo = new Todo();
        Assert.That(newTodo, Is.Not.Null);
    }

    [Test]
    public void CreateTodo_ShouldBeEqual()
    {
        var newTodo = new Todo(10, "Test Todo", "This Todo is a Test Todo", false);
        Assert.That(newTodo.TodoId, Is.EqualTo(10));
        Assert.That(newTodo.Name, Is.EqualTo("Test Todo"));
        Assert.That(newTodo.Description, Is.EqualTo("This Todo is a Test Todo"));
        Assert.That(newTodo.Done, Is.False);
    }
}