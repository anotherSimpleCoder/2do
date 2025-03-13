using NUnit.Framework;

namespace Backend.UnitTests;

[TestFixture]
public class TodoBuilderTests
{
    [Test]
    public void BuildEmptyTodo_ShouldNotBeNull()
    {
        var builtTodo = new TodoBuilder()
            .Build();
        
        Assert.That(builtTodo, Is.Not.Null);
    }

    [Test]
    public void BuildTodoWithCustomName_ShouldBeEqual()
    {
        var builtTodo = new TodoBuilder()
            .Name("Test Todo")
            .Build();
        
        Assert.That(builtTodo, Is.Not.Null);
        Assert.That(builtTodo.Name, Is.EqualTo("Test Todo"));
    }
    
    [Test]
    public void BuildTodoWithDescription_SholdBeEqual()
    {
        var builtTodo = new TodoBuilder()
            .Description("Test Todo")
            .Build();
        
        Assert.That(builtTodo, Is.Not.Null);
        Assert.That(builtTodo.Description, Is.EqualTo("Test Todo"));
    }

    [Test]
    public void BuildTodoWithDone_ShouldBeEqual()
    {
        var builtTodo = new TodoBuilder()
            .Done(true)
            .Build();
        
        Assert.That(builtTodo, Is.Not.Null);
        Assert.That(builtTodo.Done, Is.True);
    }
}