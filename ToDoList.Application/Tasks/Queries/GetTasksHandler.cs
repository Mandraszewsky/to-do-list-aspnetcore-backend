using Microsoft.EntityFrameworkCore;
using ToDoList.Application.CQRS;
using ToDoList.Application.Data;

namespace ToDoList.Application.Tasks.Queries;

public class GetTasksHandler(IApplicationDbContext dbContext) : IQueryHandler<GetTasksQuery, GetTasksResult>
{
    public async Task<GetTasksResult> Handle(GetTasksQuery query, CancellationToken cancellationToken)
    {

        var tasks = await dbContext.Tasks.OrderBy(x => x.DueDate).ToListAsync(cancellationToken);

        var response = new GetTasksResult(tasks);

        return response;
    }
}