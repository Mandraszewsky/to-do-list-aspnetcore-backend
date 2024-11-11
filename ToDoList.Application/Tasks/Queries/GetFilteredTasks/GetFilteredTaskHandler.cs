using Microsoft.EntityFrameworkCore;
using ToDoList.Application.CQRS;
using ToDoList.Application.Data;

namespace ToDoList.Application.Tasks.Queries.GetFilteredTasks;

public class GetFilteredTaskHandler(IApplicationDbContext dbContext) : IQueryHandler<GetFilteredTaskQuery, GetFilteredTasksResult>
{
    public async Task<GetFilteredTasksResult> Handle(GetFilteredTaskQuery query, CancellationToken cancellationToken)
    {
        var filterParams = query.Task;
        var tasksAsQueryable = dbContext.Tasks.AsQueryable();

        if (!String.IsNullOrEmpty(filterParams.Title))
            tasksAsQueryable = tasksAsQueryable.Where(x => x.Title.ToUpper().Contains(filterParams.Title.ToUpper()));

        if (!String.IsNullOrEmpty(filterParams.Summary))
            tasksAsQueryable = tasksAsQueryable.Where(x => x.Summary.ToUpper().Contains(filterParams.Summary.ToUpper()));

        if (!String.IsNullOrEmpty(filterParams.DueDate))
            tasksAsQueryable = tasksAsQueryable.Where(x => x.DueDate.Day == DateTime.Parse(filterParams.DueDate).Day);

        var tasks = await tasksAsQueryable.ToListAsync();

        var response = new GetFilteredTasksResult(tasks);

        return response;
    }
}
