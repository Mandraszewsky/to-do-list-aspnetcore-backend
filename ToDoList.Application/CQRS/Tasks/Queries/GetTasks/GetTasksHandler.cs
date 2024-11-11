using Microsoft.EntityFrameworkCore;
using ToDoList.Application.Data;

namespace ToDoList.Application.CQRS.Tasks.Queries.GetTasks;

public class GetTasksHandler(IApplicationDbContext dbContext) : IQueryHandler<GetTasksQuery, GetTasksResult>
{
    public async Task<GetTasksResult> Handle(GetTasksQuery query, CancellationToken cancellationToken)
    {

        var tasks = await dbContext.Tasks.OrderBy(x => x.DueDate).ToListAsync(cancellationToken);

        var response = new GetTasksResult(tasks);

        return response;
    }
}