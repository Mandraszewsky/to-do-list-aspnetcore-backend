using Carter;
using MediatR;
using ToDoList.Application.Tasks.Queries;

namespace ToDoList.API.Endpoints;

public class GetTasks : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/orders", async (ISender sender) =>
        {
            var result = await sender.Send(new GetTasksQuery());

            return Results.Ok(result);
        })
        .WithName("GetTasks")
        .Produces<GetTasksResult>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Tasks")
        .WithDescription("Get Tasks");
    }
}