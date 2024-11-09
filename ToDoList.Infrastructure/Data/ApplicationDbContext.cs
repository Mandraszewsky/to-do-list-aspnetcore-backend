using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ToDoList.Application.Data;

namespace ToDoList.Infrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<Domain.Models.Task> Tasks { get; set; }
    public DbSet<Domain.Models.User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
