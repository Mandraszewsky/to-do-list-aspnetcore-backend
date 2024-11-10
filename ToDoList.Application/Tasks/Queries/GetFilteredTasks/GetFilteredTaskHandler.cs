using Microsoft.EntityFrameworkCore;
using ToDoList.Application.CQRS;
using ToDoList.Application.Data;
using ToDoList.Domain.Models;

namespace ToDoList.Application.Tasks.Queries.GetFilteredTasks;

public class GetFilteredTaskHandler(IApplicationDbContext dbContext) : IQueryHandler<GetFilteredTaskQuery, GetFilteredTasksResult>
{
    public async Task<GetFilteredTasksResult> Handle(GetFilteredTaskQuery query, CancellationToken cancellationToken)
    {

        //var tasks = dbContext.Tasks.Where(x => x.UserId.Equals(query.userId)).AsQueryable();

        //tasks = tasks.Where();

        var tasks = await dbContext.Tasks.ToListAsync(cancellationToken);

        var response = new GetFilteredTasksResult(tasks);

        return response;
    }
}
