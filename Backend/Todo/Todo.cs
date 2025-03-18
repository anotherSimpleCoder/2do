using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Backend;

public class Todo : IEquatable<Todo>
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TodoId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Done { get; set; }
    
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

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}