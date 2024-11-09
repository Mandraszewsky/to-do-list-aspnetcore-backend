using Microsoft.EntityFrameworkCore;

namespace ToDoList.Application.Data;

public interface IApplicationDbContext
{
    DbSet<Domain.Models.Task> Tasks { get; }
    DbSet<Domain.Models.User> Users { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
