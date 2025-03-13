namespace Backend;

public class TodoBuilder
{
    private int _todoId = -1;
    private string _name;
    private string _description;
    private bool _done;

    public TodoBuilder TodoId(int todoId)
    {
        _todoId = todoId;
        return this;
    }

    public TodoBuilder Name(string name)
    {
        _name = name;
        return this;
    }

    public TodoBuilder Description(string description)
    {
        _description = description;
        return this;
    }

    public TodoBuilder Done(bool done)
    {
        _done = done;
        return this;
    }

    public Todo Build()
    {
        return new Todo(_todoId, _name, _description, _done);
    }
}