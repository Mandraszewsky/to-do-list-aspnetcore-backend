using ToDoList.Domain.Models;

namespace ToDoList.Infrastructure.Data.Extensions;

internal class InitialData
{
    public static IEnumerable<User> Users =>
    new List<User>
    {
            User.Create(new Guid("58c49479-ec65-4de2-86e7-033c546291aa"), "Jan Kowalski"),
            User.Create(new Guid("189dc8dc-990f-48e0-a37b-e6f2b60b9d7d"), "Andrzej Nowak"),
            User.Create(new Guid("4f136e9f-193f-12e2-a36b-e6f3b70b9d8d"), "Marcin Kowal"),
    };

    public static IEnumerable<Domain.Models.Task> Tasks =>
    new List<Domain.Models.Task>
    {
            Domain.Models.Task.Create(Guid.NewGuid(), new Guid("58c49479-ec65-4de2-86e7-033c546291aa"), "Task #1", "Washing #1", new DateTime(2024,11,11)),
            Domain.Models.Task.Create(Guid.NewGuid(), new Guid("58c49479-ec65-4de2-86e7-033c546291aa"), "Task #2", "Washing #2", new DateTime(2024,11,12)),
            Domain.Models.Task.Create(Guid.NewGuid(), new Guid("189dc8dc-990f-48e0-a37b-e6f2b60b9d7d"), "Task #1", "Shopping #1", new DateTime(2024,11,12)),
            Domain.Models.Task.Create(Guid.NewGuid(), new Guid("189dc8dc-990f-48e0-a37b-e6f2b60b9d7d"), "Task #2", "Shopping #2", new DateTime(2024,11,13)),
            Domain.Models.Task.Create(Guid.NewGuid(), new Guid("4f136e9f-193f-12e2-a36b-e6f3b70b9d8d"), "Task #1", "Reading #1", new DateTime(2024,11,13)),
            Domain.Models.Task.Create(Guid.NewGuid(), new Guid("4f136e9f-193f-12e2-a36b-e6f3b70b9d8d"), "Task #2", "Reading #2", new DateTime(2024,11,14)),
    };
}
