using Microsoft.EntityFrameworkCore;
using ToDoList.Infrastructure.Data;
using Xunit;

namespace ToDoList.Infrastructure.Tests;

public class ToDoListRepositoryTests
{
    private readonly ApplicationDbContext _context;

    public ToDoListRepositoryTests()
    {
        var connectionString = "Server=localhost;Database=ToDoDb;User Id=sa;Password=sa1234;Integrated Security=True;TrustServerCertificate=True";

        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer(connectionString).Options;

        _context = new ApplicationDbContext(options);
    }

    [Fact]
    public async System.Threading.Tasks.Task GetTasksAfterSeedDataAsync_ShouldBe_7()
    {
        var taskCounter = await _context.Tasks.CountAsync();

        Assert.Equal(7, taskCounter);
    }

    [Fact]
    public async System.Threading.Tasks.Task GetUsersAfterSeedDataAsync_ShouldBe_4()
    {
        var userCounter = await _context.Users.CountAsync();

        Assert.Equal(4, userCounter);
    }

    [Fact]
    public async System.Threading.Tasks.Task AddSpecifiedTaskToDatabase_ShouldAddTaskToDatabase()
    {
        var task = new Domain.Models.Task
        {
            Id = new Guid("68c49479-ec65-4de2-86e7-033c546291aa"),
            UserId = new Guid("58c49479-ec65-4de2-86e7-033c546291aa"),
            Title = "Test Title #1",
            Summary = "Test Summary #1",
            DueDate = DateTime.UtcNow,
        };

        await _context.Tasks.AddAsync(task);
        await _context.SaveChangesAsync();

        var result = await _context.Tasks.FirstOrDefaultAsync(x => x.Id.Equals(task.Id));

        Assert.NotNull(result);
    }

    [Fact]
    public async System.Threading.Tasks.Task DeleteSpecifiedTaskFromDatabase_ShouldDeleteTaskFromDatabase()
    {

        var firstResult = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == new Guid("68c49479-ec65-4de2-86e7-033c546291aa"));
        Assert.NotNull(firstResult);

        _context.Tasks.Remove(firstResult);
        await _context.SaveChangesAsync();

        var secondResult = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == new Guid("68c49479-ec65-4de2-86e7-033c546291aa"));
        Assert.Null(secondResult);
    }
}
