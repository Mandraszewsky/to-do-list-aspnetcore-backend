using ToDoList.Domain.Abstractions;

namespace ToDoList.Domain.Models;

public class User : Entity<Guid>
{
    public string Name { get; set; } = default!;

    public static User Create(Guid id, string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        var user = new User { Id = id, Name = name };

        return user;
    }
}
