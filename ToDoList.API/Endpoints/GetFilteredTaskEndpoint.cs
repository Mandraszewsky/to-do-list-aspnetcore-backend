using Carter;
using MediatR;
using ToDoList.Application.CQRS.Tasks.Queries.GetFilteredTasks;

namespace ToDoList.API.Endpoints;

public class GetFilteredTaskEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/ordersFilter", async (GetFilteredTaskQuery query, ISender sender) =>
        {
            var result = await sender.Send(query);

            return Results.Ok(result);
        })
        .WithName("GetFilteredTaskEndpoint")
        .Produces<GetFilteredTasksResult>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Filtered Tasks")
        .WithDescription("Get Filtered Tasks");
    }
}
