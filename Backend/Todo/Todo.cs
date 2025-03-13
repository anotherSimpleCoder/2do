namespace Backend;

public class Todo : IEquatable<Todo>
{
    public int TodoId { get; }
    public string Name { get; }
    public string Description { get; }
    public bool Done { get; }
    
    public Todo() {}

    public Todo(int todoId, string name, string description, bool done)
    {
        TodoId = todoId;
        Name = name;
        Description = description;
        Done = done;
    }

    public bool Equals(Todo obj)
    {
        return TodoId == obj.TodoId
            && Name == obj.Name
            && Description == obj.Description
            && Done == obj.Done;
    }
}